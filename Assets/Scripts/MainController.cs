using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public bool isPaused = false;

    private AudioSource bubblePoppingSound;

    [SerializeField]
    private Transform prefabBubble;

    public GameObject successPanel;
    public GameObject pausePanel;

    public float minX = -2.35f;
    public float minY = -4.53f;
    public float maxX = 2.35f;
    public float maxY = 4.53f;

    public bool instatiateRightSide = false; 

    private float nextActionTime = 0.0f;

    public Image centreBubbleImage;

    public TextMeshProUGUI centreBubbleText;
    public Text numberToReachText;
    public int numberToReach;

    private void Start()
    {
        bubblePoppingSound = GetComponent<AudioSource>();

        StartGame();
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += GetRandomPeriod();
            CreateNewBubble();
        }

        if (centreBubbleText.text != Core.TotalBubbleCount.ToString())
        {
            bubblePoppingSound.Play();

            LeanTween.scale(centreBubbleText.gameObject, new Vector3(1.3f, 1.3f, 0), 0.2f).setOnComplete(ScaleDown);

            centreBubbleText.SetText(Core.TotalBubbleCount.ToString());
        }

        if (Core.IsDraggingBubble)
        {
            LeanTween.scale(centreBubbleImage.gameObject, new Vector3(1.3f, 1.3f, 0), 0.2f).setOnComplete(ScaleImageDown);
        }

        CheckIfGameOver();
    }

    private void ScaleDown()
    {
        LeanTween.scale(centreBubbleText.gameObject, new Vector3(1, 1, 0), 0.2f);
    }

    private void ScaleImageDown()
    {
        LeanTween.scale(centreBubbleImage.gameObject, new Vector3(1, 1, 0), 0.2f);
    }

    private void CheckIfGameOver()
    {
        if (Core.TotalBubbleCount == numberToReach && !successPanel.activeSelf)
        {
            Core.SetPlayMode(false);
            Time.timeScale = 0;
            successPanel.SetActive(true);
        }
    }

    private void StartGame()
    {
        nextActionTime = Time.time;
        numberToReach = Random.Range(1, 100);
        numberToReachText.text = numberToReach.ToString();

        Core.ResetBubbleCount();
    }

    private void CreateNewBubble()
    {
        var bubble = Instantiate(prefabBubble, GetRandomPosition(), Quaternion.identity);
        bubble.GetComponent<Renderer>().material.color = GetRandomColour();
        var scaleBubbleSize = Random.Range(-0.2f, 0.3f);
        bubble.localScale += new Vector3(scaleBubbleSize, scaleBubbleSize, 0);
    }

    private Vector2 GetRandomPosition()
    {
        float randomX;
        if (instatiateRightSide)
        {
            instatiateRightSide = false;
            randomX = Random.Range(minX, -0.5f);
        }
        else
        {
            instatiateRightSide = true;
            randomX = Random.Range(0.5f, maxX);
        }

        float randomY = -5.46f;
        return new Vector2(randomX, randomY);
    }

    private float GetRandomPeriod()
    {
        return Random.Range(0.4f, 2.2f);
    }

    private Color GetRandomColour()
    {
        var randomNumber = Random.Range(1, 7);
        switch (randomNumber)
        {
            case 1:
                return Core.Yellow;
            case 2:
                return Core.Blue;
            case 3:
                return Core.Pink;
            case 4:
                return Core.Purple;
            case 5:
                return Core.Turquoise;
            case 6:
                return Core.TomatoRed;
            default:
                return Core.Blue;
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pausePanel.SetActive(true);
        }
    }
}
