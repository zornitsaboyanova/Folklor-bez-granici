using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class Shopska : MonoBehaviour
{
    [SerializeField]
    GameObject shopska, shopska1;

    public bool canPress;


    void Start()
    {
        
        shopska1.SetActive(false);
        if (PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
        {
            shopska.SetActive(true);
        }
        else
        {
            shopska.SetActive(false);
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
        }
    }
    private void OnMouseDown()
    {
        if(canPress == true && PlayerPrefs.GetInt("ShopskaDone", 0) == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
        }
    }
}
