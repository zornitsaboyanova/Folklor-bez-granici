using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    PauseMenu pauseMenu;
    [SerializeField]
    GameObject optionsMenuCanvas;
    [SerializeField]
    GameObject mainMenuCanvas;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume ); 
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void OptionsExit()
    {
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
