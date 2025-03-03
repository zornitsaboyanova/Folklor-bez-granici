using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Shopska : MonoBehaviour
{
    [SerializeField]
    GameObject shopska, shopska1, shopska2, shopska3, rodopska;
    public bool canPress;

    void Start()
    {
        shopska1.SetActive(false);
        shopska3.SetActive(false);
        if (PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
        {
            shopska.SetActive(true);
            shopska2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
        {
            shopska.SetActive(false);
            shopska2.SetActive(true);
        }
    }
    private void OnMouseOver()
    {
        if (canPress == true)
        {
            if(PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
            {
                shopska1.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
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
            if (PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
            {
                shopska1.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
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
            if (PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
            }
            else if (PlayerPrefs.GetInt("ShopskaDone", 0) == 1)
            {
                //PhoneScan.isEverythingShopskaScanned = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
            }
        }
    }
}
