using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Rodopska : MonoBehaviour
{
    [SerializeField] GameObject rodopska, rodopska1;
    [SerializeField] GameObject rawImage;

    [SerializeField] VideoPlayer horoPlayer;

    bool canPress = true;

    private const string slowGraovskoHoroKey = "SlowGraovskoHoroShown";

    void Start()
    {

        rodopska1.SetActive(false);
        rawImage.SetActive(false);
        if (PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
        {
            if(PlayerPrefs.GetInt("RodopskaDone", 0) == 0)
            {
                if (PlayerPrefs.GetInt(slowGraovskoHoroKey, 0) == 0)
                {
                    rawImage.SetActive(true);
                    StartCoroutine(WaitForHoro());
                }
                else
                {
                    rawImage.SetActive(false);
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
        horoPlayer.Play();
        yield return new WaitForSeconds(50f);
        PlayerPrefs.SetInt(slowGraovskoHoroKey, 1);
        PlayerPrefs.Save();
        rawImage.SetActive(false);
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
