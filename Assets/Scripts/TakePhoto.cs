using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics.Tracing;
using UnityEngine.InputSystem;

public class TakePhoto : MonoBehaviour
{
    public GameObject rawImage;
    public Camera phoneCamera;         // Assign the in-game camera
    public RenderTexture renderTexture; // Assign the phone screen RenderTexture
    //public Image galleryImage;         // Assign the UI Image in the Gallery Panel
    public GameObject galleryMenuPanel, shopskaGalleryPanel;    // Reference to the gallery panel
    public GameObject cameraScanPanel;
    public GameObject phonePanel;

    public bool isGalleryOpen = false;
    public bool isShopskaGalleryOpen = false;
    public GameObject phoneGameObject;
    Phone phone;

    public GameObject imageSlotPrefab;
    public Transform galleryGrid;
    private List<string> savedPhotoPaths = new List<string>();

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
        if (isGalleryOpen)
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
            phone.isPhoneScanning = true;
            GL.Clear(true, true, Color.black);
            rawImage.SetActive(false);

        }
        else if(isShopskaGalleryOpen == true)
        {
            shopskaGalleryPanel.SetActive(false);
            isShopskaGalleryOpen = false;
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

        savedPhotoPaths.Add(filePath);

        OpenGallery();

        yield return new WaitForEndOfFrame();
        phoneCamera.targetTexture = null;

    }
    void OpenGallery()
    {
        if(shopskaGalleryPanel != null)
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
        foreach (Transform child in galleryGrid)
        {
            Destroy(child.gameObject);
        }

        foreach (string filePath in savedPhotoPaths)
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
}
