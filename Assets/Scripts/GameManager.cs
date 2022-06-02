using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private Button backButton;
    private Button quitButton;
    private bool isGameActive = false;

    private void Start()
    {
        backButton = GameObject.Find("Back").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();
    }

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
}
