using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.IO;
using System.IO;

public class GalleryManager : MonoBehaviour
{
    public GameObject imageSlotPrefab;
    public Transform galleryGrid;
    private List<string> savedPhotoPaths = new List<string>();
    
    public void LoadGallery()
    {
        foreach (Transform child in galleryGrid)
        {
            Destroy(child.gameObject);
        }

        foreach(string filePath in savedPhotoPaths)
        {
            StartCoroutine(LoadPhoto(filePath));
        }
    }

    private IEnumerator LoadPhoto(string filePath)
    {
        if(File.Exists(filePath))
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
