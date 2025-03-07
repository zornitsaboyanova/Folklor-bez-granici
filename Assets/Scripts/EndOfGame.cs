using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] GameObject endOfGamePanel, endOfGamePanel1, endOfGamePanel2;
    void Start()
    {
        endOfGamePanel.SetActive(true);
        endOfGamePanel1.SetActive(false);
        endOfGamePanel2.SetActive(false);
    }
    public void MainMenuEnter()
    {
        endOfGamePanel1.SetActive(true);
    }
    public void MainMenuExit()
    {
        endOfGamePanel1.SetActive(false);
    }
    public void MainMenuOnClick()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        SceneManager.LoadScene("Menus");
    }
    public void ExitGameEnter()
    {
        endOfGamePanel2.SetActive(true);
    }
    public void ExitGameExit()
    {
        endOfGamePanel2.SetActive(false);
    }
    public void ExitGameOnClick()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        Application.Quit();
    }
}
