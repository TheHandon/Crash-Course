using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.GetInt("ViewedInstructions") < 1)
        {
            PlayerPrefs.SetInt("ViewedInstructions", 2);
            Instructions();
        }
        else
        {
            GoToMap();
        }
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Instructions()
    {
        if (PlayerPrefs.GetInt("ViewdInstructions") != 2) PlayerPrefs.SetInt("ViewedInstructions", 1);
        SceneManager.LoadScene("Instructions");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            PlayerPrefs.Save();
            Application.Quit();
        }
        else if (SceneManager.GetActiveScene().name == "Instructions" && PlayerPrefs.GetInt("ViewedInstructions") == 2)
        {
            GoToMap();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void GoToMap()
    {
        SceneManager.LoadScene("Map1");
    }
}