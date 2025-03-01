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
    PhoneScan phoneScan;
    [SerializeField] GameObject cameraScan;
    bool isPlaying = false;
    bool canPlay = false;
    void Start()
    {
        phoneScan = cameraScan.GetComponent<PhoneScan>();
        phonePanel.SetActive(false);
        filesMenuPanel.SetActive(true);
        filePanel.SetActive(true);
        playButton.SetActive(true);
        playButtonImage.SetActive(true);
        stopButton.SetActive(false);
        stopButtonImage.SetActive(false);

        if (PhoneScan.isEverythingScanned == true)
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
        }
        else
        {
            fadeImage.SetActive(true);
            lockImage.SetActive(true);
        }
    }

    void Update()
    {
        if (PhoneScan.isEverythingScanned == true)
        {
            canPlay = true;
        }
        if (phoneScan.isNosiaWomanScanned && this.gameObject.name == "File1_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
        if (phoneScan.isNosiaManScanned && this.gameObject.name == "File2_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
        if (phoneScan.isShevicaScanned && this.gameObject.name == "File3_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
        if (phoneScan.isFoodScanned && this.gameObject.name == "File4_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
        if (phoneScan.isMusicalInstrumentScanned && this.gameObject.name == "File5_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
        if (phoneScan.isMusicalInstrument1Scanned && this.gameObject.name == "File6_panel")
        {
            fadeImage.SetActive(false);
            lockImage.SetActive(false);
            canPlay = true;
        }
    }
    public void PlayButtonOnCLick()
    {
        if (canPlay)
        {
            audioSource.Play();
            isPlaying = true;

            playButton.SetActive(false);
            playButtonImage.SetActive(false);

            stopButton.SetActive(true);
            stopButtonImage.SetActive(true);

        }


    }
    public void StopButtonOnClick()
    {
        if (canPlay)
        {
            audioSource.Stop();
            isPlaying = false;

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
