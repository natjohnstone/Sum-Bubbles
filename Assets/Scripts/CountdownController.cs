using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public GameObject restartPanel;

    private float currentTime = 0f;
    private float startingTime = 45f;

    [SerializeField]
    private Text countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (currentTime == 0)
        {
            TimesUp();
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;

            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
    }

    public void TimesUp()
    {
        if (!restartPanel.activeSelf)
        {
            Time.timeScale = 0;
            restartPanel.SetActive(true);
        }
    }
}
