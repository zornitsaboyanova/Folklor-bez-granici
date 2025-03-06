using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject phoneCanvas;
    Phone phone;

    public GameObject interactionUI, interactionUI1;
    public bool isPlayerNear = false;

    private const string shopskaDoneKey = "ShopskaDone";
    private const string rodopskaDoneKey = "RodopskaDone";
    private const string pirinskaDoneKey = "PirinskaDone";

    void Start()
    {
        phone = phoneCanvas.GetComponent<Phone>();

        interactionUI.SetActive(false);
        interactionUI1.SetActive(false);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Shopska")
        {
            if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerPrefs.GetInt("EverythingShopskaScanned", 0) == 1)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerPrefs.SetInt(shopskaDoneKey, 1);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Map");
                }
                else
                {
                    interactionUI.SetActive(false);
                    interactionUI1.SetActive(true);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Rodopska")
        {
            if(isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerPrefs.GetInt("EverythingRodopskaScanned", 0) == 1)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerPrefs.SetInt(rodopskaDoneKey, 1);
                    PlayerPrefs.Save();
                    //Pirinska.isActive = true;
                    SceneManager.LoadScene("Map");
                }
                else
                {
                    interactionUI.SetActive(false);
                    interactionUI1.SetActive(true);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Pirinska")
        {
            if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerPrefs.GetInt("EverythingPirinskaScanned", 0) == 1)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerPrefs.SetInt(pirinskaDoneKey, 1);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Map");
                }
                else
                {
                    interactionUI.SetActive(false);
                    interactionUI1.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!phone.isPhoneOpen)
            {
                isPlayerNear = true;
                interactionUI.SetActive(true);
            }
            else
            {
                isPlayerNear = false;
                interactionUI.SetActive(false);
                interactionUI1.SetActive(false);
            }
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
