using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private const string shopskaNosiaWomanKey = "ShopskaNosiaWomanScanned";
    private const string shopskaNosiaManKey = "ShopskaNosiaManScanned";
    private const string pitkaKey = "PitkaScanned";
    private const string shopskaShevicaKey = "ShopskaShevicaScanned";
    private const string gydulkaKey = "GydulkaScanned";
    private const string typanKey = "TypanScanned";

    
    private const string rodopskaNosiaWomanKey = "RodopskaNosiaWomanScanned";
    private const string rodopskaNosiaManKey = "RodopskaNosiaManScanned";
    private const string banicaKey = "BanicaScanned";
    private const string rodopskaShevicaKey = "rodopskaShevicaScanned";
    private const string gaidaKey = "GaidaKey";

    private const string everythingShopskaKey = "EverythingShopskaScanned";
    private const string everythingRodopskaKey = "EverythingRodopskaScanned";

    public AudioSource audioSource1, audioSource2, audioSource3, audioSource4, audioSource5, audioSource6;
    private void Start()
    {

    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(shopskaNosiaWomanKey, 0) == 1 && PlayerPrefs.GetInt(shopskaNosiaManKey, 0) == 1 && PlayerPrefs.GetInt(pitkaKey, 0) == 1 && PlayerPrefs.GetInt(shopskaShevicaKey, 0) == 1 && PlayerPrefs.GetInt(gydulkaKey, 0) == 1 && PlayerPrefs.GetInt(typanKey, 0) == 1)
        {
            PlayerPrefs.SetInt(everythingShopskaKey, 1);
            PlayerPrefs.Save();
        }
        else if(PlayerPrefs.GetInt(rodopskaNosiaWomanKey, 0) == 1 && PlayerPrefs.GetInt(rodopskaNosiaManKey, 0) == 1 && PlayerPrefs.GetInt(banicaKey, 0) == 1 && PlayerPrefs.GetInt(rodopskaShevicaKey, 0) == 1 && PlayerPrefs.GetInt(gaidaKey, 0) == 1)
        {
            PlayerPrefs.SetInt(everythingRodopskaKey, 1);
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
        //Храната се засича от камерата, чрез raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == nosiaWomanObject)
            {
                if (!isPlayingNosiaWoman)
                {
                    //Когато телефонът засече храната на масата и аудиото не е пуснато - аудиото се пуска
                    isPlayingNosiaWoman = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingNosiaWoman)
                {
                    //Когато телефонът спре да засича храната и аудиото все още е пуснато - то да спре
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
        //Храната се засича от камерата, чрез raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == nosiaManObject)
            {
                if (!isPlayingNosiaMan)
                {
                    //Когато телефонът засече храната на масата и аудиото не е пуснато - аудиото се пуска
                    isPlayingNosiaMan = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingNosiaMan)
                {
                    //Когато телефонът спре да засича храната и аудиото все още е пуснато - то да спре
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
        //Храната се засича от камерата, чрез raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {;
            if (hit.transform == foodObject)
            {
                if (!isPlayingFood)
                {
                    //Когато телефонът засече храната на масата и аудиото не е пуснато - аудиото се пуска
                    isPlayingFood = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingFood)
                {
                    //Когато телефонът спре да засича храната и аудиото все още е пуснато - то да спре
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
        //Шевиците се засичат от камерата, чрез raycast
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == shevicaObject)
            {
                if (!isPlayingShevica)
                {
                    //Когато телефонът засече шевица и аудиото не е пуснато - аудиото се пуска
                    isPlayingShevica = true;
                    detectionCoroutine = StartCoroutine(DelaySound());
                }
            }
            else
            {
                if (isPlayingShevica)
                {
                    //Когато телефонът спре да засича шевицата, аудиото се спира.
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
        yield return new WaitForSeconds(1.0f); //изчаква се 1 секунда преди да се пусне аудиото

        if (isPlayingNosiaWoman)
        {
            audioSource1.Play(); //аудиото се пуска

            yield return new WaitWhile(() => audioSource1.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(shopskaNosiaWomanKey, 1);
                PlayerPrefs.Save();
            }
            else if (SceneManager.GetActiveScene().name == "Rodopska")
            {
                PlayerPrefs.SetInt(rodopskaNosiaWomanKey, 1);
                PlayerPrefs.Save();
            }
        }
        else if (isPlayingNosiaMan)
        {
            audioSource2.Play();

            yield return new WaitWhile(() => audioSource2.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(shopskaNosiaManKey, 1);
                PlayerPrefs.Save();
            }
            else if (SceneManager.GetActiveScene().name == "Rodopska")
            {
                PlayerPrefs.SetInt(rodopskaNosiaManKey, 1);
                PlayerPrefs.Save();
            }
        }
        else if (isPlayingFood)
        {
            audioSource3.Play();

            yield return new WaitWhile( () => audioSource3.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(pitkaKey, 1);
                PlayerPrefs.Save();
            }
            else if (SceneManager.GetActiveScene().name == "Rodopska")
            {
                PlayerPrefs.SetInt(banicaKey, 1);
                PlayerPrefs.Save();
            }
        }
        else if (isPlayingShevica)
        {
            audioSource4.Play();

            yield return new WaitWhile(()=> audioSource4.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(shopskaShevicaKey, 1);
                PlayerPrefs.Save();
            }
            else if (SceneManager.GetActiveScene().name == "Rodopska")
            {
                PlayerPrefs.SetInt(rodopskaShevicaKey, 1);
                PlayerPrefs.Save();
            }
        }
        else if (isPlayingMusicalInstrument)
        {
            audioSource5.Play();

            yield return new WaitWhile(() => audioSource5.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(gydulkaKey, 1);
                PlayerPrefs.Save();
            }
            else if (SceneManager.GetActiveScene().name == "Rodopska")
            {
                PlayerPrefs.SetInt(gaidaKey, 1);
                PlayerPrefs.Save();
            }
        }
        else if (isPlayingMusicalInstrument1)
        {
            audioSource6.Play();

            yield return new WaitWhile(() => audioSource6.isPlaying);

            if (SceneManager.GetActiveScene().name == "Shopska")
            {
                PlayerPrefs.SetInt(typanKey, 1);
                PlayerPrefs.Save();
            }
        }
    }
}
