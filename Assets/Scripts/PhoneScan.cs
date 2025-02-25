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
    public AudioSource audioSource;

    private Coroutine detectionCoroutine;

    private bool isPlayingNosiaWoman = false;
    private bool isPlayingNosiaMan = false;
    private bool isPlayingFood = false;
    private bool isPlayingShevica = false;
    private bool isPlayingMusicalInstrument = false;
    private bool isPlayingMusicalInstrument1 = false;
    public bool isNosiaWomanScanned= false;
    public bool isNosiaManScanned = false;
    public bool isFoodScanned = false;
    public bool isShevicaScanned = false;
    public bool isMusicalInstrumentScanned = false;
    public bool isMusicalInstrument1Scanned = false;
    public static bool isEverythingScanned = false;
    private void Start()
    {

    }
    private void Update()
    {
        if (isNosiaWomanScanned && isNosiaManScanned && isFoodScanned && isShevicaScanned && isMusicalInstrumentScanned && isMusicalInstrument1Scanned)
        {
            isEverythingScanned=true;
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
        //������� �� ������� �� �������� ���� RectTransform
        Vector3 screenPos = mainCamera.WorldToScreenPoint(nosiaWomanObject.position);

        if (RectTransformUtility.RectangleContainsScreenPoint(cameraScanPanel, screenPos))
        {
            Debug.Log("Woman");
            if (!isPlayingNosiaWoman)
            {
                //������ ��������� ������ ����� � ������� �� � ������� - �� �� ����� �������
                isPlayingNosiaWoman = true;
                isNosiaWomanScanned = true;
                detectionCoroutine = StartCoroutine(DelaySound());
            }
        }
        else
        {
            if (isPlayingNosiaWoman)
            {
                //������ ��������� ���� �� ������ ������� � ������� � ������� - ������� �� �����
                isPlayingNosiaWoman = false;
                if(detectionCoroutine != null)
                {
                    StopCoroutine(detectionCoroutine);
                }
            }
        }
    }
    void NosiaManScan()
    {
        //������� �� ������� �� �������� ���� RectTransform
        Vector3 screenPos = mainCamera.WorldToScreenPoint(nosiaManObject.position);

        if (RectTransformUtility.RectangleContainsScreenPoint(cameraScanPanel, screenPos))
        {
            Debug.Log("Man");
            if (!isPlayingNosiaMan)
            {
                //������ ��������� ������ ����� � ������� �� � ������� - �� �� ����� �������
                isPlayingNosiaMan = true;
                isNosiaManScanned = true;
                detectionCoroutine = StartCoroutine(DelaySound());
            }
        }
        else
        {
            if (isPlayingNosiaMan)
            {
                //������ ��������� ���� �� ������ ������� � ������� � ������� - ������� �� �����
                isPlayingNosiaMan = false;
                if (detectionCoroutine != null)
                {
                    StopCoroutine(detectionCoroutine);
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

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform == foodObject)
            {
                Debug.Log("Food");
                if(!isPlayingFood)
                {
                    //������ ��������� ������ ������� �� ������ � ������� �� � ������� - ������� �� �����
                    isPlayingFood= true;
                    isFoodScanned = true;
                    detectionCoroutine= StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingFood)
                {
                    //������ ��������� ���� �� ������ ������� � ������� ��� ��� � ������� - �� �� ����
                    isPlayingFood = false;
                    if(detectionCoroutine != null)
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
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height/2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform == shevicaObject)
            {
                Debug.Log("Shevica");
                if (!isPlayingShevica)
                {
                    //������ ��������� ������ ������ � ������� �� � ������� - ������� �� �����
                    isPlayingShevica = true;
                    isShevicaScanned = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingShevica)
                {
                    //������ ��������� ���� �� ������ ��������, ������� �� �����.
                    isPlayingShevica = false;
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
        Ray ray = mainCamera.ScreenPointToRay (screenCenter);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform == musicalInstrumentObject)
            {
                Debug.Log("Gydulka");
                if (!isPlayingMusicalInstrument)
                {
                    isPlayingMusicalInstrument = true;
                    isMusicalInstrumentScanned = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingMusicalInstrument)
                {
                    isPlayingMusicalInstrument = false;
                    if(detectionCoroutine != null)
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
                Debug.Log("Typan");
                if (!isPlayingMusicalInstrument1)
                {
                    isPlayingMusicalInstrument1 = true;
                    isMusicalInstrument1Scanned = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingMusicalInstrument1)
                {
                    isPlayingMusicalInstrument1 = false;
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

        if (isPlayingNosiaWoman || isPlayingNosiaMan || isPlayingFood || isPlayingShevica || isPlayingMusicalInstrument || isPlayingMusicalInstrument1) 
        {
            audioSource.Play(); //������� �� �����
        }
    }
}
