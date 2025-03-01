using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScan : MonoBehaviour
{
    public Camera mainCamera;
    public Transform nosiaWomanObject;
    public Transform nosiaManObject;
    public Transform foodObject;
    public Transform shevicaObject;
    public Transform musicalInstrumentObject;
    public Transform musicalInstrumentObject1;
    public RectTransform cameraScanPanel;

    private Coroutine detectionCoroutine;

    private bool isPlayingNosiaWoman = false;
    private bool isPlayingNosiaMan = false;
    private bool isPlayingFood = false;
    private bool isPlayingShevica = false;
    private bool isPlayingMusicalInstrument = false;
    private bool isPlayingMusicalInstrument1 = false;
    public bool isNosiaWomanScanned = false;
    public bool isNosiaManScanned = false;
    public bool isFoodScanned = false;
    public bool isShevicaScanned = false;
    public bool isMusicalInstrumentScanned = false;
    public bool isMusicalInstrument1Scanned = false;
    public static bool isEverythingScanned = false;

    private const string nosiaWomanKey = "NosiaWomanScanned";
    private const string nosiaManKey = "NosiaManScanned";
    private const string foodKey = "FoodScanned";
    private const string shevicaKey = "ShevicaScanned";
    private const string musicalInstrumentKey = "MusicalInstrumentScanned";
    private const string musicalInstrument1Key = "MusicalInstrument1Scanned";
    private const string everythingKey = "EverythingScanned";

    public AudioSource audioSource1, audioSource2, audioSource3, audioSource4, audioSource5, audioSource6;
    private void Start()
    {

    }
    private void Update()
    {
        if (isNosiaWomanScanned && isNosiaManScanned && isFoodScanned && isShevicaScanned && isMusicalInstrumentScanned && isMusicalInstrument1Scanned)
        {
            isEverythingScanned = true;
            PlayerPrefs.SetInt(everythingKey, 1);
            PlayerPrefs.Save();
        }
        NosiaWomanScan();
        NosiaManScan();
        FoodScan();
        ShevicaScan();
        MusicalInstrumentScan();
        MusicalInstrument1Scan();
    }
    void NosiaWomanScan()
    {
        //������� �� ������ �� ��������, ���� raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == nosiaWomanObject)
            {
                if (!isPlayingNosiaWoman)
                {
                    //������ ��������� ������ ������� �� ������ � ������� �� � ������� - ������� �� �����
                    isPlayingNosiaWoman = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isNosiaWomanScanned = true;
                    PlayerPrefs.SetInt(nosiaWomanKey, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingNosiaWoman)
                {
                    //������ ��������� ���� �� ������ ������� � ������� ��� ��� � ������� - �� �� ����
                    isPlayingNosiaWoman = false;
                    audioSource1.Stop();
                    if (detectionCoroutine != null)
                    {
                        StopCoroutine(detectionCoroutine);
                    }
                }
            }
        }
    }
    void NosiaManScan()
    {
        //������� �� ������ �� ��������, ���� raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == nosiaManObject)
            {
                if (!isPlayingNosiaMan)
                {
                    //������ ��������� ������ ������� �� ������ � ������� �� � ������� - ������� �� �����
                    isPlayingNosiaMan = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isNosiaManScanned = true;
                    PlayerPrefs.SetInt(nosiaWomanKey, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingNosiaMan)
                {
                    //������ ��������� ���� �� ������ ������� � ������� ��� ��� � ������� - �� �� ����
                    isPlayingNosiaMan = false;
                    audioSource2.Stop();
                    if (detectionCoroutine != null)
                    {
                        StopCoroutine(detectionCoroutine);
                    }
                }
            }
        }
    }
    void FoodScan()
    {
        //������� �� ������ �� ��������, ���� raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == foodObject)
            {
                if (!isPlayingFood)
                {
                    //������ ��������� ������ ������� �� ������ � ������� �� � ������� - ������� �� �����
                    isPlayingFood = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isFoodScanned = true;
                    PlayerPrefs.SetInt(foodKey, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingFood)
                {
                    //������ ��������� ���� �� ������ ������� � ������� ��� ��� � ������� - �� �� ����
                    isPlayingFood = false;
                    audioSource3.Stop();
                    if (detectionCoroutine != null)
                    {
                        StopCoroutine(detectionCoroutine);
                    }
                }
            }
        }
    }
    void ShevicaScan()
    {
        //�������� �� ������� �� ��������, ���� raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == shevicaObject)
            {
                if (!isPlayingShevica)
                {
                    //������ ��������� ������ ������ � ������� �� � ������� - ������� �� �����
                    isPlayingShevica = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isShevicaScanned = true;
                    PlayerPrefs.SetInt(shevicaKey, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingShevica)
                {
                    //������ ��������� ���� �� ������ ��������, ������� �� �����.
                    isPlayingShevica = false;
                    audioSource4.Stop();
                    if (detectionCoroutine != null)
                    {
                        StopCoroutine(detectionCoroutine);
                    }
                }
            }
        }
    }
    void MusicalInstrumentScan()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == musicalInstrumentObject)
            {
                if (!isPlayingMusicalInstrument)
                {
                    isPlayingMusicalInstrument = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isMusicalInstrumentScanned = true;
                    PlayerPrefs.SetInt(musicalInstrumentKey, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingMusicalInstrument)
                {
                    isPlayingMusicalInstrument = false;
                    audioSource5.Stop();
                    if (detectionCoroutine != null)
                    {
                        StartCoroutine(DelaySound());
                    }
                }
            }
        }
    }
    void MusicalInstrument1Scan()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == musicalInstrumentObject1)
            {
                if (!isPlayingMusicalInstrument1)
                {
                    isPlayingMusicalInstrument1 = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                    isMusicalInstrument1Scanned = true;
                    PlayerPrefs.SetInt(musicalInstrument1Key, 1);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                if (isPlayingMusicalInstrument1)
                {
                    isPlayingMusicalInstrument1 = false;
                    audioSource6.Stop();
                    if (detectionCoroutine != null)
                    {
                        StartCoroutine(DelaySound());
                    }
                }
            }
        }
    }
    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(1.0f); //������� �� 1 ������� ����� �� �� ����� �������

        if (isPlayingNosiaWoman)
        {
            audioSource1.Play(); //������� �� �����
        }
        else if (isPlayingNosiaMan)
        {
            audioSource2.Play();
        }
        else if (isPlayingFood)
        {
            audioSource3.Play();
        }
        else if (isPlayingShevica)
        {
            audioSource4.Play();
        }
        else if (isPlayingMusicalInstrument)
        {
            audioSource5.Play();
        }
        else if (isPlayingMusicalInstrument1)
        {
            audioSource6.Play();
        }
    }
}
