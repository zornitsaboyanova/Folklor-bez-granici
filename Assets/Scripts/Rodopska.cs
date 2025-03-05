using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Rodopska : MonoBehaviour
{
    [SerializeField] GameObject rodopska, rodopska1;
    [SerializeField] GameObject horoVideoCanvas;

    public static bool isActive;
    bool canPress = true;

    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer1;

    private const string fastGraovskoKey = "FastGraovskoShown";
    void Start()
    {
        PlayerPrefs.DeleteKey(fastGraovskoKey);
        PlayerPrefs.Save();


        if (isActive == true)
        {
            if (PlayerPrefs.GetInt(fastGraovskoKey, 0) == 0)
            {
                horoVideoCanvas.SetActive(true);
                StartCoroutine(FastGraovskoPlaying());
                rodopska.SetActive(true);
                rodopska1.SetActive(false);
            }
            else
            {
                horoVideoCanvas.SetActive(false);
                rodopska.SetActive(true);
                rodopska1.SetActive(false);
            }
        }
        else
        {
            horoVideoCanvas.SetActive(false);
        }
    }

    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (canPress == true && isActive == true)
        {
            rodopska1.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (canPress == true && isActive == true)
        {
            rodopska1.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("SlowGraovskoShown", 0) == 1)
        {
            if (canPress == true && isActive == true)
            {
                SceneManager.LoadScene("Rodopska");
            }
        }
    }
    IEnumerator FastGraovskoPlaying()
    {
        videoPlayer1.Stop();
        canPress = false;
        videoPlayer.Play();
        yield return new WaitWhile(() => videoPlayer.isPlaying);
        horoVideoCanvas.SetActive(false);
        PlayerPrefs.SetInt(fastGraovskoKey, 1);
        PlayerPrefs.Save();
        canPress = true;
    }
}
