using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pirinska : MonoBehaviour
{
    [SerializeField] GameObject pirinska, pirinska1;

    [SerializeField] GameObject horoCanvas;

    [SerializeField] VideoPlayer horoPlayer;

    bool canPress = true;

    private const string fastGraovskoKey = "FastGraovskoHoroShown";
    void Start()
    {
        pirinska1.SetActive(false);
        horoCanvas.SetActive(false);
        if (PlayerPrefs.GetInt("RodopskaDone", 0) == 1)
        {
            if (PlayerPrefs.GetInt("PirinskaDone", 0) == 0)
            {
                pirinska.SetActive(true);
                if(PlayerPrefs.GetInt(fastGraovskoKey, 0) == 0)
                {
                    StartCoroutine(WaitForHoro());
                }
            }
            else
            {
                horoCanvas.SetActive(false);
                pirinska.SetActive(false);
            }
        }
        else
        {
            pirinska.SetActive(false);
        }
    }
    IEnumerator WaitForHoro()
    {
        canPress = false;
        horoCanvas.SetActive(true);
        horoPlayer.Play();
        yield return new WaitForSeconds(53f);
        PlayerPrefs.SetInt(fastGraovskoKey, 1);
        PlayerPrefs.Save();
        horoCanvas.SetActive(false);
        canPress = true;
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
