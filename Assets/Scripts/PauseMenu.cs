using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu, backToMainMenu, exit;
    public bool isPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
        backToMainMenu.SetActive(false);
        exit.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc is pressed");
            PauseGame();
        }
    }
    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }
    public void BackToMainMeunuEnter()
    {
        pauseMenu.SetActive(false);
        backToMainMenu.SetActive(true);
    }
    public void BackToMainMenuExit()
    {
        pauseMenu.SetActive(true);
        backToMainMenu.SetActive(false);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menus");
    }
    public void ExitEnter()
    {
        pauseMenu.SetActive(false);
        exit.SetActive(true);
    }
    public void ExitExit()
    {
        pauseMenu.SetActive(true);
        exit.SetActive(false);
    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Application.Quit();
    }
}
