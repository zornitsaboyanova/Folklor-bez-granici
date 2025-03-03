using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics.Tracing;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TakePhotoShopska : MonoBehaviour
{
    public GameObject rawImage;
    public Camera phoneCamera;
    public RenderTexture renderTexture;
    public GameObject galleryMenuPanel, shopskaGalleryPanel;
    public GameObject cameraScanPanel;
    public GameObject phonePanel;

    public bool isGalleryOpen = false;
    public bool isShopskaGalleryOpen = false;

    public GameObject phoneGameObject;
    Phone phone;

    public GameObject imageSlotPrefab;
    public Transform galleryGrid;
    private List<string> savedPhotoPathsShopska = new List<string>();
    private const string shopskaPhotosKey = "SavedShopskaPhotos";
    private void Start()
    {
        phone = phoneGameObject.GetComponent<Phone>();
        LoadGallery();
    }
    private void Update()
    {

    }
    public void PhoneButtonClick()
    {
        if (isShopskaGalleryOpen)
        {
            phone.canTakeAPhoto = true;
            galleryMenuPanel.SetActive(false);
            shopskaGalleryPanel.SetActive(false);
            phonePanel.SetActive(false);
            cameraScanPanel.SetActive(true);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isGalleryOpen = false;
            isShopskaGalleryOpen = false;
            phone.isPhoneScanning = true;
            GL.Clear(true, true, Color.black);
            rawImage.SetActive(false);

        }
        else if (phone.isShopskaGalleryOpen)
        {
            phonePanel.SetActive(false);
            galleryMenuPanel.SetActive(true);
            shopskaGalleryPanel.SetActive(false);
            phone.isShopskaGalleryOpen = false;
            isGalleryOpen = true;
        }
    }


    public void TakeAPhoto()
    {
        rawImage.SetActive(true);
        StartCoroutine(CapturePhoto());
    }

    private IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        phoneCamera.targetTexture = renderTexture;
        phoneCamera.Render();

        RenderTexture.active = renderTexture;
        Texture2D photo = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        photo.Apply();
        RenderTexture.active = null;

        string fileName = "photo_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Save the photo
        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        //Debug.Log("Photo saved at: " + filePath);

        savedPhotoPathsShopska.Add(filePath);
        SavePhotoPathsShopska();

        OpenGallery();

        yield return new WaitForEndOfFrame();
        phoneCamera.targetTexture = null;

    }
    void OpenGallery()
    {
        if (shopskaGalleryPanel != null)
        {
            phone.canTakeAPhoto = false;
            shopskaGalleryPanel.SetActive(true);
            isShopskaGalleryOpen = true;
            cameraScanPanel.SetActive(false);
            Time.timeScale = 0.0f;
        }

        LoadGallery();
    }
    public void LoadGallery()
    {
        //delete old photos
        foreach (Transform child in galleryGrid)
        {
            Destroy(child.gameObject);
        }

        LoadPhotoPathsShopska();

        foreach (string filePath in savedPhotoPathsShopska)
        {
            StartCoroutine(LoadPhoto(filePath));
        }

    }

    private IEnumerator LoadPhoto(string filePath)
    {
        if (File.Exists(filePath))
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            GameObject newImageSlot = Instantiate(imageSlotPrefab, galleryGrid);
            newImageSlot.GetComponent<RawImage>().texture = texture;
        }
        yield return null;
    }

    private void SavePhotoPathsShopska()
    {
        string pathsString = string.Join("|", savedPhotoPathsShopska);
        PlayerPrefs.SetString(shopskaPhotosKey, pathsString);
        PlayerPrefs.Save();
    }

    private void LoadPhotoPathsShopska()
    {
        savedPhotoPathsShopska.Clear();

        if (PlayerPrefs.HasKey(shopskaPhotosKey))
        {
            string pathsString = PlayerPrefs.GetString(shopskaPhotosKey);
            if (!string.IsNullOrEmpty(pathsString))
            {
                savedPhotoPathsShopska.AddRange(pathsString.Split('|'));
            }
        }
    }
    
}