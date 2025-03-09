using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics.Tracing;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TakePhotoPirinska : MonoBehaviour
{
    public GameObject rawImage;
    public Camera phoneCamera;
    public RenderTexture renderTexture;
    public GameObject galleryMenuPanel, pirinskaGalleryPanel;
    public GameObject cameraScanPanel;
    public GameObject phonePanel;

    public bool isGalleryOpen = false;
    public bool isPirinskaGalleryOpen = false;

    public GameObject phoneGameObject;
    Phone phone;

    public GameObject imageSlotPrefab;
    public Transform galleryGrid;
    private List<string> savedPhotoPathsRodopska = new List<string>();
    private const string pirinskaPhotosKey = "SavedPirinskaPhotos";
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
        if (isPirinskaGalleryOpen)
        {
            phone.canTakeAPhoto = true;
            galleryMenuPanel.SetActive(false);
            pirinskaGalleryPanel.SetActive(false);
            phonePanel.SetActive(false);
            cameraScanPanel.SetActive(true);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isGalleryOpen = false;
            isPirinskaGalleryOpen = false;
            phone.isPhoneScanning = true;
            GL.Clear(true, true, Color.black);
            rawImage.SetActive(false);

        }
        else if (phone.isPirinskaGalleryOpen)
        {
            phonePanel.SetActive(false);
            galleryMenuPanel.SetActive(true);
            pirinskaGalleryPanel.SetActive(false);
            phone.isRodopskaGalleryOpen = false;
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

        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);

        savedPhotoPathsRodopska.Add(filePath);
        SavePhotoPathsRodopska();

        OpenGallery();

        yield return new WaitForEndOfFrame();
        phoneCamera.targetTexture = null;

    }
    void OpenGallery()
    {
        if (pirinskaGalleryPanel != null)
        {
            phone.canTakeAPhoto = false;
            pirinskaGalleryPanel.SetActive(true);
            isPirinskaGalleryOpen = true;
            cameraScanPanel.SetActive(false);
            Time.timeScale = 0.0f;
        }

        LoadGallery();
    }
    public void LoadGallery()
    {
        foreach (Transform child in galleryGrid)
        {
            Destroy(child.gameObject);
        }

        LoadPhotoPathsRodopska();

        foreach (string filePath in savedPhotoPathsRodopska)
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

    private void SavePhotoPathsRodopska()
    {
        string pathsString = string.Join("|", savedPhotoPathsRodopska);
        PlayerPrefs.SetString(pirinskaPhotosKey, pathsString);
        PlayerPrefs.Save();
    }

    private void LoadPhotoPathsRodopska()
    {
        savedPhotoPathsRodopska.Clear();

        if (PlayerPrefs.HasKey(pirinskaPhotosKey))
        {
            string pathsString = PlayerPrefs.GetString(pirinskaPhotosKey);
            if (!string.IsNullOrEmpty(pathsString))
            {
                savedPhotoPathsRodopska.AddRange(pathsString.Split('|'));
            }
        }
    }

}