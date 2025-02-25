using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;
using System.Linq.Expressions;

public class Phone : MonoBehaviour
{
    [SerializeField]
    GameObject phoneOffPanel, phonePanel, cameraScanPanel, pauseMenuCanvas, cameraScanButtonClickPanel, galleryMenuPanel, filesPanel;
    [SerializeField] GameObject shopskaGalleryPanel;
    public bool isPhoneOpen = false;
    bool isPhoneOn = false;
    public bool isPhoneScanning = false;
    public bool isGalleryOpen = false;
    public bool canTakeAPhoto = false;

    TakePhoto takePhoto;
    void Start()
    {
        takePhoto = shopskaGalleryPanel.GetComponent<TakePhoto>();

        phoneOffPanel.SetActive(false);
        cameraScanPanel.SetActive(false);
        cameraScanButtonClickPanel.SetActive(false);
        phonePanel.SetActive(false);
        galleryMenuPanel.SetActive(false);
        shopskaGalleryPanel.SetActive(false);
        filesPanel.SetActive(false);
        
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        takePhoto.rawImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.B))
        {
            PhoneAction();
        }
       if (Input.GetKeyDown(KeyCode.Space) && cameraScanPanel == true)
        {
            cameraScanButtonClickPanel.SetActive(true);

            if (takePhoto.isGalleryOpen == false && canTakeAPhoto == true)
            {
                galleryMenuPanel.SetActive(true);
                shopskaGalleryPanel.SetActive(true);
                takePhoto.isGalleryOpen = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                takePhoto.TakeAPhoto();
            }
        }
       else if (Input.GetKeyUp(KeyCode.Space) && cameraScanPanel == true)
        {
            cameraScanButtonClickPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && cameraScanPanel == true && isPhoneOn == true && isPhoneOpen == true && isPhoneScanning == true)
        {
            isPhoneScanning = false;
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
            phoneOffPanel.SetActive(false);
            phonePanel.SetActive(true);
            isPhoneOn = true;
        }
        else if (isPhoneOn == true)
        {
            phonePanel.SetActive(false);
            phoneOffPanel.SetActive(true);
            isPhoneOn = false;
        }
    }
    public void CameraIconOnClick()
    {
        canTakeAPhoto = true;
        phonePanel.SetActive(false);
        cameraScanPanel.SetActive(true);
        Time.timeScale = 1.0f;
        isPhoneScanning = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void PhotosIconClick()
    {
        isGalleryOpen = true;
        galleryMenuPanel.SetActive(true);
    }
    public void FilesIconCLick()
    {
        filesPanel.SetActive(true);
        phonePanel.SetActive(false);
    }
    public void ShopskaGalleryButtonOnClick()
    {
        takePhoto.isShopskaGalleryOpen = true;
        shopskaGalleryPanel.SetActive(true);
    }
    public void GalleryPhoneButtonOnClick()
    {
        if (isGalleryOpen && !takePhoto.isShopskaGalleryOpen)
        {
            Debug.Log("Button is pressed!");
            galleryMenuPanel.SetActive(false);
            phonePanel.SetActive(true);
        }
    }
}
