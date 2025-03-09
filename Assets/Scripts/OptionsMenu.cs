using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Versioning;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField]
    GameObject optionsMenuCanvas;
    [SerializeField]
    GameObject mainMenuCanvas;

    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle fullScreenToggle;
    Resolution[] allResolutions;
    bool isFullScreen;
    int selectedResolution;
    List<Resolution> selectedResolutionList = new List<Resolution>();
    private void Start()
    {
        isFullScreen = true;
        allResolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();
        string newResolution;
        foreach (Resolution resolution in allResolutions)
        {
            newResolution = resolution.width.ToString() + " x " + resolution.height.ToString();
            if (!resolutionStringList.Contains(newResolution))
            {
                resolutionStringList.Add(newResolution);
                selectedResolutionList.Add(resolution);
            }
        }


        resolutionDropdown.AddOptions(resolutionStringList);

    }
    public void ChangeResolution()
    {
        selectedResolution = resolutionDropdown.value;
        Screen.SetResolution(selectedResolutionList[selectedResolution].width, selectedResolutionList[selectedResolution].height, isFullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume ); //��������� �� �����
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //��������� �� ��������
    }
    public void SetFullScreen(bool isFullScreen)
    {
        isFullScreen = fullScreenToggle.isOn;
        Screen.SetResolution(selectedResolutionList[selectedResolution].width, selectedResolutionList[selectedResolution].height, isFullScreen);

    }
    public void OptionsExit()
    {
        //�������� �� ����������� � ������� � ��������� ����
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
