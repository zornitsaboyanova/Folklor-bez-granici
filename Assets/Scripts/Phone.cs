using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.SceneManagement;

public class Phone : MonoBehaviour
{
    [SerializeField]
    public GameObject phoneOffPanel, phonePanel, cameraScanPanel, pauseMenuCanvas, cameraScanButtonClickPanel, galleryMenuPanel, filesPanel;
    [SerializeField] GameObject shopskaGalleryPanel, rodopskaGalleryPanel;
    public bool isPhoneOpen = false;
    public bool isPhoneOn = false;
    public bool isPhoneScanning = false;
    public bool isGalleryOpen = false;
    public bool canTakeAPhoto = false;
    public bool isShopskaGalleryOpen = false;
    public bool isRodopskaGalleryOpen = false;

    TakePhotoShopska takePhotoShopska;
    TakePhotoRodopska takePhotoRodopska;

    void Start()
    {
        takePhotoShopska = shopskaGalleryPanel.GetComponent<TakePhotoShopska>();
        takePhotoRodopska = rodopskaGalleryPanel.GetComponent<TakePhotoRodopska>();

        phoneOffPanel.SetActive(false);
        cameraScanPanel.SetActive(false);
        cameraScanButtonClickPanel.SetActive(false);
        phonePanel.SetActive(false);
        galleryMenuPanel.SetActive(false);
        shopskaGalleryPanel.SetActive(false);
        rodopskaGalleryPanel.SetActive(false);
        filesPanel.SetActive(false);
        
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        takePhotoShopska.rawImage.SetActive(false);
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.B) && isPhoneOn == false)
        {
            PhoneAction();
        }
       if (Input.GetKeyDown(KeyCode.Space) && cameraScanPanel == true &&isPhoneScanning == true)
        {
            cameraScanButtonClickPanel.SetActive(true);

            if(SceneManager.GetActiveScene().name == "Shopska")
            {
                Debug.Log("Shopska scene");
                if (isShopskaGalleryOpen == false && canTakeAPhoto == true)
                {
                    galleryMenuPanel.SetActive(true);
                    shopskaGalleryPanel.SetActive(true);
                    takePhotoShopska.isGalleryOpen = true;
                    takePhotoShopska.isShopskaGalleryOpen = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    takePhotoShopska.TakeAPhoto();
                }
            }
            else if(SceneManager.GetActiveScene().name == "Rodopska")
            {
                Debug.Log("Rodopska Scene");
                galleryMenuPanel.SetActive(true);
                rodopskaGalleryPanel.SetActive(true);
                takePhotoRodopska.isGalleryOpen = true;
                takePhotoRodopska.isRodopskaGalleryOpen = true;
                Cursor.lockState= CursorLockMode.None;
                Cursor.visible = true;
                takePhotoRodopska.TakeAPhoto();
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
        isShopskaGalleryOpen = true;
        shopskaGalleryPanel.SetActive(true);
    }
    public void RodopskaGalleryButtonOnClick()
    {
        isRodopskaGalleryOpen = true;
        rodopskaGalleryPanel.SetActive(true);
    }
    public void GalleryPhoneButtonOnClick()
    {
        if (isGalleryOpen && !takePhotoShopska.isShopskaGalleryOpen || !takePhotoRodopska.isRodopskaGalleryOpen)
        {
            Debug.Log("Button is pressed!");
            galleryMenuPanel.SetActive(false);
            phonePanel.SetActive(true);
            isGalleryOpen = false;
        }
    }
}
