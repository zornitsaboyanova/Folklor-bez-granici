using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Shopska : MonoBehaviour
{
    [SerializeField]
    GameObject shopska, shopska1;
    bool canPress;
    void Start()
    {
        //shopska.transform.position = new Vector3(-0.0038f, 1.0375f, 0f);
        shopska.SetActive(true);
        shopska1.SetActive(false);
        canPress = true;
    }
    private void OnMouseOver()
    {
        if (canPress == true)
        {
            shopska1.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        shopska1.SetActive(false);
    }
    private void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shopska");
    }
}
