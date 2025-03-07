using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pirinska : MonoBehaviour
{
    [SerializeField] GameObject pirinska, pirinska1, pirinska2;
    [SerializeField] GameObject endOfGameVideoCanvas;
    [SerializeField] GameObject endOfGameCanvas;

    [SerializeField] VideoPlayer videoPlayer;

    bool canPress = true;

    void Start()
    {
        pirinska1.SetActive(false);
        pirinska2.SetActive(false);
        endOfGameVideoCanvas.SetActive(false);
        endOfGameCanvas.SetActive(false);
        if (PlayerPrefs.GetInt("RodopskaDone", 0) == 1)
        {
            if (PlayerPrefs.GetInt("PirinskaDone", 0) == 0)
            {
                pirinska.SetActive(true);
            }
            else
            {
                pirinska2.SetActive(true);
                StartCoroutine(EndOfGameVideo());
            }
        }
        else
        {
            pirinska.SetActive(false);
        }
    }
    IEnumerator EndOfGameVideo()
    {
        canPress = false;
        endOfGameVideoCanvas.SetActive(true);
        videoPlayer.Play();
        yield return new WaitForSeconds(8f);
        endOfGameVideoCanvas.SetActive(false);
        endOfGameCanvas.SetActive(true);
    }
    private void OnMouseOver()
    {
        if (canPress == true && PlayerPrefs.GetInt("RodopskaDone", 0) == 1)
        {
            pirinska1.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (canPress == true && PlayerPrefs.GetInt("RodopskaDone", 0) == 1)
        {
            pirinska1.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (canPress == true && PlayerPrefs.GetInt("RodopskaDone", 0) == 1 && PlayerPrefs.GetInt("PirinskaDone", 0) == 0)
        {
            SceneManager.LoadScene("Pirinska");
        }
    }
}
