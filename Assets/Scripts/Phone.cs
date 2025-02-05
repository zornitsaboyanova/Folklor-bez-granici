using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Phone : MonoBehaviour
{
    [SerializeField]
    GameObject phoneOffPanel, phonePanel, cameraScanPanel, pauseMenuCanvas, cameraScanButtonClickPanel;
    bool isPhoneOpen = false;
    bool isPhoneOn = false;
    void Start()
    {
        phoneOffPanel.SetActive(false);
        cameraScanButtonClickPanel.SetActive(false);
        phonePanel.SetActive(false);
        cameraScanPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B is pressed");
            PhoneAction();
        }
       if (Input.GetKeyDown(KeyCode.Space) && cameraScanPanel == true)
        {
            cameraScanButtonClickPanel.SetActive(true);
        }
       else if (Input.GetKeyUp(KeyCode.Space) && cameraScanPanel == true)
        {
            cameraScanButtonClickPanel.SetActive(false);
        }
       if (Input.GetKeyDown(KeyCode.Escape) && cameraScanPanel == true && isPhoneOn == true && isPhoneOpen == true)
        {
            cameraScanPanel.SetActive(false);
            phonePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.0f;
        }
    }
    public void PhoneAction()
    {
        if (isPhoneOpen == false)
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 0;
            phoneOffPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPhoneOpen = true;
        }
        else if (isPhoneOpen == true)
        {
            phoneOffPanel.SetActive(false);
            Time.timeScale = 1.0f;
            pauseMenuCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPhoneOpen = false;
        }

    }
    public void PhoneButtonOnClick()
    {
        if (isPhoneOn == false)
        {
            Debug.Log("Unlocking the phone!");
            phoneOffPanel.SetActive(false);
            phonePanel.SetActive(true);
            isPhoneOn = true;
        }
        else if(isPhoneOn == true)
        {
            Debug.Log("Locking the phone!");
            phonePanel.SetActive(false);
            phoneOffPanel.SetActive(true);
            isPhoneOn = false;
        }
    }
    public void CameraIconOnClick()
    {
        Time.timeScale = 1.0f;
        phonePanel.SetActive(false);
        cameraScanPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
