using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button backButton;
    public Button quitButton;
    public Button optionsMenuButton;
    public GameObject trueOptions;
    private Camera mainCamera;
    public float zoomFov;
    public Text fovText;

    private bool isGameActive = false;

    private void Start()
    {
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        mainCamera.fieldOfView = zoomFov;
        fovText.text = "FOV: " + zoomFov;
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
        pauseMenu.gameObject.SetActive(true);
        trueOptions.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
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

    public void OptionsUI()
    {
        quitButton.gameObject.SetActive(false);
        optionsMenuButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        trueOptions.gameObject.SetActive(true);
    }

    public void BackOptionsUI()
    {
        quitButton.gameObject.SetActive(true);
        optionsMenuButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        trueOptions.gameObject.SetActive(false);
    }

    public void FOVSlider(float zoom)
    {
        zoomFov = zoom;
    }
}
