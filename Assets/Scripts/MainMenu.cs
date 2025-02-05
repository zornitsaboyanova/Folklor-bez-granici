using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, startGame, options, exitGame, optionsMenuCanvas;

    private void Start()
    {
        mainMenu.SetActive(true);
        startGame.SetActive(false);
        options.SetActive(false);
        exitGame.SetActive(false);
    }
    public void StartGameEnter()
    {
        mainMenu.SetActive(false);
        startGame.SetActive(true);
    }
    public void StartGameExit()
    {
        mainMenu.SetActive(true);
        startGame.SetActive(false);
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
    public void OptionsEnter()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void OptionsExit()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    public void LoadOptions()
    {
        optionsMenuCanvas.SetActive(true);
    }
    public void ExitEnter()
    {
        mainMenu.SetActive(false);
        exitGame.SetActive(true);
    }
    public void ExitExit()
    {
        mainMenu.SetActive(true);
        exitGame.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
