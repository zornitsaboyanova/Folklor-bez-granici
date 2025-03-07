using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FilesManager : MonoBehaviour
{
    [SerializeField]
    GameObject phonePanel,filesMenuPanel, filePanel, playButton, stopButton, playButtonImage, stopButtonImage, fadeImage, lockImage;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField] GameObject cameraScan;

    void Start()
    {
        phonePanel.SetActive(false);
        filesMenuPanel.SetActive(true);
        filePanel.SetActive(true);
        playButton.SetActive(true);
        playButtonImage.SetActive(true);
        stopButton.SetActive(false);
        stopButtonImage.SetActive(false);

    }

    void Update()
    {

        if(!audioSource.isPlaying && !playButton.activeSelf)
        {
            playButton.SetActive(true);
            playButtonImage.SetActive(true);
            stopButton.SetActive(false);
            stopButtonImage.SetActive(false);
        }

        if (PlayerPrefs.GetInt("ShopskaNosiaWomanScanned", 0) == 1 && this.gameObject.name == "File1_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("ShopskaNosiaManScanned", 0) == 1 && this.gameObject.name == "File2_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PitkaScanned", 0) == 1 && this.gameObject.name == "File3_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("ShopskaShevicaScanned", 0) == 1 && this.gameObject.name == "File4_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GydulkaScanned", 0) == 1 && this.gameObject.name == "File5_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("TypanScanned", 0) == 1 && this.gameObject.name == "File6_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        if (PlayerPrefs.GetInt("RodopskaNosiaWomanScanned", 0) == 1 && this.gameObject.name == "File7_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("RodopskaNosiaManScanned", 0) == 1 && this.gameObject.name == "File8_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("BanicaScanned", 0) == 1 && this.gameObject.name == "File9_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("RodopskaShevicaScanned", 0) == 1 && this.gameObject.name == "File10_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GaidaScanned", 0) == 1 && this.gameObject.name == "File11_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        if (PlayerPrefs.GetInt("PirinskaNosiaWomanScanned", 0) == 1 && this.gameObject.name == "File12_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PirinskaNosiaManScanned", 0) == 1 && this.gameObject.name == "File13_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PirinskaPitkaScanned", 0) == 1 && this.gameObject.name == "File14_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PirinskaShevicaScanned", 0) == 1 && this.gameObject.name == "File15_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("TamburaScanned", 0) == 1 && this.gameObject.name == "File16_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }

    }
    public void PlayButtonOnCLick()
    {
        if (fadeImage.activeSelf == false)
        {
            audioSource.Play();

            playButton.SetActive(false);
            playButtonImage.SetActive(false);

            stopButton.SetActive(true);
            stopButtonImage.SetActive(true);

        }

    }
    public void StopButtonOnClick()
    {
        if (fadeImage.activeSelf == false)
        {
            audioSource.Stop();

            stopButton.SetActive(false);
            stopButtonImage.SetActive(false);

            playButton.SetActive(true);
            playButtonImage.SetActive(true);

        }
    }

    public void PhoneButtonOnClick()
    {
        filesMenuPanel.SetActive(false);
        phonePanel.SetActive(true);
    }
}
