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
    [SerializeField]
    GameObject optionsMenuCanvas;
    [SerializeField]
    GameObject mainMenuCanvas;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume ); //Настройки за звука
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //Настройки за качество
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; //Настройки за цял екран
    }
    public void OptionsExit()
    {
        //Излизане от настройките и връщане в основното меню
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
