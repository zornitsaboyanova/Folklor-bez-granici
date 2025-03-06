using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    [SerializeField] GameObject task1Panel, task1Done;
    [SerializeField] GameObject task2Panel, task2Done;
    [SerializeField] GameObject task3Panel, task3Done;
    [SerializeField] GameObject task4Panel, task4Done;
    [SerializeField] GameObject task5Panel, task5Done;
    [SerializeField] GameObject task6Panel, task6Done;
    [SerializeField] GameObject task7Panel, task7Done;
    [SerializeField] GameObject task8Panel, task8Done;
    [SerializeField] GameObject task9Panel, task9Done;
    [SerializeField] GameObject task10Panel, task10Done;
    [SerializeField] GameObject task11Panel, task11Done;
    [SerializeField] GameObject task12Panel, task12Done;

    public GameObject phoneCanvas;
    public GameObject cameraScanPanel;
    public GameObject shopskaGalleryPanel;
    public GameObject door;
    [SerializeField] GameObject dialogue3Canvas;

    TakePhotoShopska takePhotoShopska;
    Phone phone;
    DoorInteraction doorInteraction;

    private const string task1Key = "Task1DoneShopska";
    private const string task2Key = "Task2DoneShopska";
    private const string task3Key = "Task3DoneShopska";
    private const string task4Key = "Task4DoneShopska";
    private const string task5Key = "Task5DoneShopska";
    private const string task6Key = "Task6DoneShopska";
    private const string task7Key = "Task7DoneShopska";
    private const string task8Key = "Task8DoneShopska";
    private const string task9Key = "Task9DoneShopska";
    private const string task10Key = "Task10DoneShopska";
    private const string task11Key = "Task11DoneShopska";
    private const string task12Key = "Task12DoneShopska";
    private const string tasksDoneKey = "TasksDoneKeyShopska";
    private void Start()
    {
        phone = phoneCanvas.GetComponent<Phone>();
        takePhotoShopska = shopskaGalleryPanel.GetComponent<TakePhotoShopska>();
        doorInteraction = door.GetComponent<DoorInteraction>();

        dialogue3Canvas.SetActive(false);

        task1Panel.SetActive(false);
        task1Done.SetActive(false);
        task2Panel.SetActive(false);
        task2Done.SetActive(false);
        task3Panel.SetActive(false);
        task3Done.SetActive(false);
        task4Panel.SetActive(false);
        task4Done.SetActive(false);
        task5Panel.SetActive(false);
        task5Done.SetActive(false);
        task6Panel.SetActive(false);
        task6Done.SetActive(false);
        task7Panel.SetActive(false);
        task7Done.SetActive(false);
        task8Panel.SetActive(false);
        task8Done.SetActive(false);
        task9Panel.SetActive(false);
        task9Done.SetActive(false);
        task10Panel.SetActive(false);
        task10Done.SetActive(false);
        task11Panel.SetActive(false);
        task11Done.SetActive(false);
        task12Panel.SetActive(false);
        task12Done.SetActive(false);

    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("Dialogue2Shown", 0) == 1 && PlayerPrefs.GetInt(task1Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task1Panel.SetActive(true);
            task1Done.SetActive(false);

            Task1();
        }
        if (PlayerPrefs.GetInt(task1Key, 0) == 1 && PlayerPrefs.GetInt(task2Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task2Panel.SetActive(true);
            task2Done.SetActive(false);

            Task2();
        }
        if (PlayerPrefs.GetInt(task2Key, 0) == 1 && PlayerPrefs.GetInt(task3Key, 0) == 0)
        {
            task1Panel.SetActive(false);
            task2Panel.SetActive(false);

            StartCoroutine(WaitForTheNextTask());
            
            task3Panel.SetActive(true);
            task3Done.SetActive(false);

            Task3();
        }
        if(PlayerPrefs.GetInt(task3Key, 0) == 1 && PlayerPrefs.GetInt(task4Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task4Panel.SetActive(true);
            task4Done.SetActive(false);

            Task4();
        }
        if(PlayerPrefs.GetInt(task4Key, 0) == 1 && PlayerPrefs.GetInt(task5Key, 0) == 0)
        {
            task3Panel.SetActive(false);
            task4Panel.SetActive(false);

            StartCoroutine(WaitForTheNextTask());
            
            task5Panel.SetActive(true);
            task5Done.SetActive(false);

            Task5();
        }
        if (PlayerPrefs.GetInt(task5Key, 0) == 1 && PlayerPrefs.GetInt(task6Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task6Panel.SetActive(true);
            task6Done.SetActive(false);

            Task6();
        }
        if (PlayerPrefs.GetInt(task6Key, 0) == 1 && PlayerPrefs.GetInt(task7Key, 0) == 0)
        {
            task5Panel.SetActive(false);
            task6Panel.SetActive(false);

            StartCoroutine(WaitForTheNextTask());
            
            task7Panel.SetActive(true);
            task7Done.SetActive(false);

            Task7();
        }
        if (PlayerPrefs.GetInt(task7Key, 0) == 1 && PlayerPrefs.GetInt(task8Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task8Panel.SetActive(true);
            task8Done.SetActive(false);

            Task8();
        }
        if (PlayerPrefs.GetInt(task8Key, 0) == 1 && PlayerPrefs.GetInt(task9Key, 0) == 0)
        {
            task7Panel.SetActive(false);
            task8Panel.SetActive(false);

            StartCoroutine(WaitForTheNextTask());
            
            task9Panel.SetActive(true);
            task9Done.SetActive(false);

            Task9();
        }
        if (PlayerPrefs.GetInt(task9Key, 0) == 1 && PlayerPrefs.GetInt(task10Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task10Panel.SetActive(true);
            task10Done.SetActive(false);

            Task10();
        }
        if (PlayerPrefs.GetInt(task10Key, 0) == 1 && PlayerPrefs.GetInt(task11Key, 0) == 0)
        {
            task9Panel.SetActive(false);
            task10Panel.SetActive(false);

            dialogue3Canvas.SetActive(true);

            if(PlayerPrefs.GetInt("Dialogue3Shown", 0) == 1)
            {
                StartCoroutine(WaitForTheNextTask());

                task11Panel.SetActive(true);
                task11Done.SetActive(false);

                Task11();
            }
        }
        if (PlayerPrefs.GetInt(task11Key, 0) == 1 && PlayerPrefs.GetInt(task12Key, 0) == 0)
        {
            StartCoroutine(WaitForTheNextTask());
            task12Panel.SetActive(true);
            task12Done.SetActive(false);

            Task12();
        }
    }
    IEnumerator WaitForTheNextTask()
    {
        yield return new WaitForSeconds(1.0f);
    }
    void Task1()
    {
        if (phone.isPhoneOpen == true)
        {
            task1Done.SetActive(true);
            PlayerPrefs.SetInt(task1Key, 1);
            PlayerPrefs.Save();
        }
        if(PlayerPrefs.GetInt(task1Key, 0) == 1)
        {
            task1Panel.SetActive(true);
            task1Done.SetActive(true);
        }
    }
    void Task2()
    {
        if (phone.isPhoneOn == true)
        {
            task2Done.SetActive(true);
            PlayerPrefs.SetInt(task2Key, 1);
            PlayerPrefs.Save();
        }
        if(PlayerPrefs.GetInt(task2Key, 0) == 1)
        {
            task2Panel.SetActive(true);
            task2Done.SetActive(true);
        }
    }
    void Task3()
    {
        if(phone.isPhoneScanning == true)
        {
            task3Done.SetActive(true);
            PlayerPrefs.SetInt(task3Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task3Key, 0) == 1)
        {
            task3Panel.SetActive(true);
            task3Done.SetActive(true);
        }
    }
    void Task4()
    {
        if(PlayerPrefs.GetInt("ShopskaNosiaWomanScanned", 0) == 1)
        {
            task4Done.SetActive(true);
            PlayerPrefs.SetInt(task4Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task4Key, 0) == 1)
        {
            task4Panel.SetActive(true);
            task4Done.SetActive(true);
        }
    }
    void Task5()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            task5Done.SetActive(true);
            PlayerPrefs.SetInt(task5Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task5Key, 0) == 1)
        {
            task5Panel.SetActive(true);
            task5Done.SetActive(true);
        }
    }
    void Task6()
    {
        if (takePhotoShopska.isButtonClicked == true)
        {
            task6Done.SetActive(true);
            PlayerPrefs.SetInt(task6Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task6Key, 0) == 1)
        {
            task6Panel.SetActive(true);
            task6Done.SetActive(true);
        }
    }
    void Task7()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            task7Done.SetActive(true);
            PlayerPrefs.SetInt(task7Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task7Key, 0) == 1)
        {
            task7Panel.SetActive(true);
            task7Done.SetActive(true);
        }
    }
    void Task8()
    {
        if (phone.isShopskaGalleryOpen == true)
        {
            task8Done.SetActive(true);
            PlayerPrefs.SetInt(task8Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task8Key, 0) == 1)
        {
            task8Panel.SetActive(true);
            task8Done.SetActive(true);
        }
    }
    void Task9()
    {
        if (phone.isPhoneOn == false)
        {
            task9Done.SetActive(true);
            PlayerPrefs.SetInt(task9Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task9Key, 0) == 1)
        {
            task9Panel.SetActive(true);
            task9Done.SetActive(true);
        }
    }
    void Task10()
    {
        if (phone.isPhoneOpen == false)
        {
            task10Done.SetActive(true);
            PlayerPrefs.SetInt(task10Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task10Key, 0) == 1)
        {
            task10Panel.SetActive(true);
            task10Done.SetActive(true);
        }
    }
    void Task11()
    {
        if(PlayerPrefs.GetInt("EverythingShopskaScanned", 0) == 1)
        {
            task11Done.SetActive(true);
            PlayerPrefs.SetInt(task11Key, 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt(task11Key, 0) == 1)
        {
            task11Panel.SetActive(true);
            task11Done.SetActive(true);
        }
    }
    void Task12()
    {
        if(doorInteraction.isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            task12Done.SetActive(true);
            PlayerPrefs.SetInt(task12Key, 1);
            PlayerPrefs.Save();
            StartCoroutine(WaitForTheNextTask());
            task11Panel.SetActive(false);
            task12Panel.SetActive(true);
        }
    }
}
