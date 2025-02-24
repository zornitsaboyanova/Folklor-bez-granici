using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rodopska : MonoBehaviour
{
    [SerializeField] GameObject rodopska, rodopska1;
    public static bool isActive;
    bool canPress = true;

    void Start()
    {
        if (isActive == true)
        {
            rodopska.SetActive(true);
            rodopska1.SetActive(false);
        }
    }

    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (canPress == true && isActive == true)
        {
            rodopska1.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (canPress == true && isActive == true)
        {
            rodopska1.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (canPress == true && isActive == true)
        {
            SceneManager.LoadScene("Rodopska");
        }
    }
}
