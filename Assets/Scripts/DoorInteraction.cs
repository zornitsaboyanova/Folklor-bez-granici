using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interactionUI, interactionUI1;
    private bool isPlayerNear = false;
    public static bool isShopskaDone = false;

    void Start()
    {
        interactionUI.SetActive(false);
        interactionUI1.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (PhoneScan.isEverythingScanned == true)
            {
                if (SceneManager.GetActiveScene().name == "Shopska")
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    isShopskaDone = true;
                    Rodopska.isActive = true;
                    SceneManager.LoadScene("Map");
                }
            }
            else
            {
                interactionUI.SetActive(false);
                interactionUI1.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactionUI.SetActive(false);
            interactionUI1.SetActive(false);
        }
    }
}
