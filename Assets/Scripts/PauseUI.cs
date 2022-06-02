using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class PauseUI : MonoBehaviour
{
    public Button backButton;
    public Button quitButton;
    private bool isGameActive = false;
    public void PauseMenu()
    {
        if (isGameActive)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    public void PauseGame()
    {
        isGameActive = false;
        Time.timeScale = 0;
        backButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        backButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
