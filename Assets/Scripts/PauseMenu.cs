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

    [SerializeField] GameObject phoneCanvas;
    Phone phone;

    public bool isPaused = false;
    private void Start()
    {
        phone = phoneCanvas.GetComponent<Phone>();

        pauseMenu.SetActive(false);
        backToMainMenu.SetActive(false);
        exit.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && phone.isPhoneOpen == false)
        {
            PauseGame(); //Играта се паузира, ако е натиснат esc бутона, а ако вече това е така, играта продължава с натискането на еsc бутона
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
        //Бутона за връщане към основното меню светва, когато мишката е върху него
        pauseMenu.SetActive(false);
        backToMainMenu.SetActive(true);
    }
    public void BackToMainMenuExit()
    {
        //Бутона за връщане към основното меню изгасва, когато мишката се магне от него
        pauseMenu.SetActive(true);
        backToMainMenu.SetActive(false);
    }
    public void LoadMainMenu()
    {
        //Основното меню се показва, когато бутона е натиснат
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("Menus");
    }
    public void ExitEnter()
    {
        //Бутона за изход от играта светва, когато мишката е върху него
        pauseMenu.SetActive(false);
        exit.SetActive(true);
    }
    public void ExitExit()
    {
        //Бутона за изход от играта изгасва, когато мишката се махне от него
        pauseMenu.SetActive(true);
        exit.SetActive(false);
    }
    public void ExitGame()
    {
        //Излиза се от играта, когато бутона е натиснат
        Time.timeScale = 1;
        isPaused = false;
        Application.Quit();
    }
}
