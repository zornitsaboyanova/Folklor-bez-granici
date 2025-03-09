using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Rodopska : MonoBehaviour
{
    [SerializeField] GameObject rodopska, rodopska1;
    [SerializeField] GameObject horoVideoCanvas;

    [SerializeField] VideoPlayer horoPlayer;

    [SerializeField] AudioSource horoSource;

    bool canPress = true;

    private const string slowGraovskoHoroKey = "SlowGraovskoHoroShown";

    void Start()
    {
        horoPlayer.audioOutputMode = VideoAudioOutputMode.None;


        rodopska1.SetActive(false);
        horoVideoCanvas.SetActive(false);
        if (PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
        {
            if(PlayerPrefs.GetInt("RodopskaDone", 0) == 0)
            {
                if (PlayerPrefs.GetInt(slowGraovskoHoroKey, 0) == 0)
                {
                    StartCoroutine(WaitForHoro());
                }
                else
                {
                    rodopska.SetActive(true);
                }
            }
            else
            {
                rodopska.SetActive(false);
            }
        }
        else
        {
            rodopska.SetActive(false);
        }
    }
    IEnumerator WaitForHoro()
    {
        canPress = false;
        horoVideoCanvas.SetActive(true);
        horoPlayer.Play();
        horoSource.Play();
        yield return new WaitForSeconds(50f);
        horoPlayer.Stop();
        horoSource.Stop();
        PlayerPrefs.SetInt(slowGraovskoHoroKey, 1);
        PlayerPrefs.Save();
        horoVideoCanvas.SetActive(false);
        canPress = true;
    }
    private void OnMouseOver()
    {
        if (canPress == true && PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
        {
            rodopska1.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (canPress == true && PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
        {
            rodopska1.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (canPress == true && PlayerPrefs.GetInt("ShopskaDone", 0) == 1 && PlayerPrefs.GetInt("RodopskaDone", 0) == 0)
        {
            SceneManager.LoadScene("Rodopska");
        }
    }
}
