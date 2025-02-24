using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public Camera phoneCamera;         // Assign the in-game camera
    public RenderTexture renderTexture; // Assign the phone screen RenderTexture
    public Image galleryImage;         // Assign the UI Image in the Gallery Panel
    public GameObject galleryPanel;    // Reference to the gallery panel
    public string saveFolder = "Gallery"; // Folder name

    public void TakeAPhoto()
    {
        StartCoroutine(CapturePhoto());
    }

    private IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture.active = renderTexture;
        Texture2D photo = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        photo.Apply();
        RenderTexture.active = null;

        // Save the photo
        byte[] bytes = photo.EncodeToPNG();
        string folderPath = Path.Combine(Application.persistentDataPath, saveFolder);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string filePath = Path.Combine(folderPath, "photo_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("Photo saved at: " + filePath);

        // Display in Gallery
        StartCoroutine(LoadPhoto(filePath));
    }

    private IEnumerator LoadPhoto(string path)
    {
        yield return new WaitForSeconds(0.5f); // Wait for the file to save

        byte[] fileData = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);

        galleryImage.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        galleryPanel.SetActive(true); // Show the gallery panel
    }
}
