using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class  MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject howtoPanel;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public bool isInPlayMode = false;

    public void Start()
    {
        if (easyButton != null)
        { 
            SetDifficulty(Core.difficultySetting);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Core.SetPlayMode(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Core.SetPlayMode(true);
    }

    public void GoToMainMenu()
    {
        Core.SetPlayMode(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0;
    }

    public void ShowOptionPage()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ShowHowToPage()
    {
        mainMenuPanel.SetActive(false);
        howtoPanel.SetActive(true);
    }

    public void BackToMainMenuPage()
    {
        mainMenuPanel.SetActive(true);
        howtoPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void SetDifficulty(string difficulty)
    {
        Core.SetDifficultySetting(difficulty);

        if (difficulty == "EASY")
        {
            easyButton.GetComponent<Image>().color = Color.white;
            mediumButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            hardButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else if (difficulty == "MEDIUM")
        {
            easyButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            mediumButton.GetComponent<Image>().color = Color.white;
            hardButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else if (difficulty == "HARD")
        {
            easyButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            mediumButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            hardButton.GetComponent<Image>().color = Color.white;
        }
    }

}
