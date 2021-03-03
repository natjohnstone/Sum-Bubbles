using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathSymbolController : MonoBehaviour
{
    public GameObject buttonObjects;

    public Button plusButton;
    public Button minusButton;
    public Button divideButton;
    public Button timesButton;

    private void Start()
    {
        var difficulty = Core.difficultySetting;
        if (difficulty == "EASY")
        {
            buttonObjects.SetActive(false);
        }

        if (difficulty == "MEDIUM")
        {
            divideButton.gameObject.SetActive(false);
            timesButton.gameObject.SetActive(false);
        }

        SetActiveButton(Core.activeMathSymbol);
    }

    public void OnSymbolClick(string symbol)
    {
        // set active symbol in core
        Core.SetMathSymbol(symbol);

        // update button images to represent clicked button
        SetActiveButton(symbol);
    }

    private void SetActiveButton(string symbol)
    {
        if (symbol == "PLUS")
        {
            plusButton.GetComponent<Image>().color = Core.ActiveButtonGrey;
            minusButton.GetComponent<Image>().color = Color.white;
            divideButton.GetComponent<Image>().color = Color.white;
            timesButton.GetComponent<Image>().color = Color.white;
        }
        else if (symbol == "MINUS")
        {
            minusButton.GetComponent<Image>().color = Core.ActiveButtonGrey;
            plusButton.GetComponent<Image>().color = Color.white;
            divideButton.GetComponent<Image>().color = Color.white;
            timesButton.GetComponent<Image>().color = Color.white;
        }
        else if (symbol == "DIVIDE")
        {
            divideButton.GetComponent<Image>().color = Core.ActiveButtonGrey;
            minusButton.GetComponent<Image>().color = Color.white;
            plusButton.GetComponent<Image>().color = Color.white;
            timesButton.GetComponent<Image>().color = Color.white;
        }
        else if (symbol == "TIMES")
        {
            timesButton.GetComponent<Image>().color = Core.ActiveButtonGrey;
            minusButton.GetComponent<Image>().color = Color.white;
            plusButton.GetComponent<Image>().color = Color.white;
            divideButton.GetComponent<Image>().color = Color.white;
        }

    }
}
