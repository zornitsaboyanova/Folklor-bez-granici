using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interactionUI;
    private bool isPlayerNear = false;
    public static bool isShopskaDone = false;

    void Start()
    {
        interactionUI.SetActive(false);
    }

    void Update()
    {
        if(isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if(PhoneScan.isEverythingScanned == true)
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
                Debug.Log("Все още не може да излезеш от стаята! Сканирай и се запознай с всички обекти първо.");
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
        }
    }
}
