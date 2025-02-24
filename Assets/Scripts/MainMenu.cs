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
        //Показва се мейн менюто
        mainMenu.SetActive(true);
        startGame.SetActive(false);
        options.SetActive(false);
        exitGame.SetActive(false);
    }
    public void StartGameEnter()
    {
        //Старт бутона светва, когато мишката е върху него
        mainMenu.SetActive(false);
        startGame.SetActive(true);
    }
    public void StartGameExit()
    {
        //Старт бутона изгасва, когато мишката се махне от него
        mainMenu.SetActive(true);
        startGame.SetActive(false);
    }
    public void StartGame()
    {
        //Когато се натисне старт бутона, се появява картата
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
    public void OptionsEnter()
    {
        //Бутона за настройки светва, когато мишката е върху него
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void OptionsExit()
    {
        //Бутона за настройки изгасва, когато мишката се махне от него
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    public void LoadOptions()
    {
        //Настройките се появяват, когато се натисне бутона за настройки
        optionsMenuCanvas.SetActive(true);
    }
    public void ExitEnter()
    {
        //Бутона за изход светва, когато мишката е върху него
        mainMenu.SetActive(false);
        exitGame.SetActive(true);
    }
    public void ExitExit()
    {
        //Бутона за изход изгасва, когато мишката се махне от него
        mainMenu.SetActive(true);
        exitGame.SetActive(false);
    }
    public void ExitGame()
    {
        //Излиза се от играта, когато се натисне бутона за изход
        Application.Quit();
    }
}
