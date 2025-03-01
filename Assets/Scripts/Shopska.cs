using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Shopska : MonoBehaviour
{
    [SerializeField]
    GameObject shopska, shopska1, shopska2, rodopska, shopska3;
    public bool canPress;

    void Start()
    {
        shopska1.SetActive(false);
        shopska3.SetActive(false);
        if (DoorInteraction.isShopskaDone == false)
        {
            shopska.SetActive(true);
            shopska2.SetActive(false);
        }
        else if (DoorInteraction.isShopskaDone == true)
        {
            shopska.SetActive(false);
            shopska2.SetActive(true);
        }
    }
    private void OnMouseOver()
    {
        if (canPress == true)
        {
            if(DoorInteraction.isShopskaDone == false)
            {
                shopska1.SetActive(true);
            }
            else if(DoorInteraction.isShopskaDone == true)
            {
                Debug.Log("Mouse is over");
                rodopska.SetActive(false);
                shopska3.SetActive(true);
            }
        }
    }
    private void OnMouseExit()
    {
        if(canPress == true)
        {
            if (DoorInteraction.isShopskaDone == false)
            {
                shopska1.SetActive(false);
            }
            else if (DoorInteraction.isShopskaDone == true)
            {
                rodopska.SetActive(true);
                shopska3.SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        if(canPress == true)
        {
            if (DoorInteraction.isShopskaDone == false)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
            }
            else if (DoorInteraction.isShopskaDone == true)
            {
                PhoneScan.isEverythingScanned = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
            }
        }
    }
}
