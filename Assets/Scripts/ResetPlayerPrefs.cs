using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public GameObject resetConfirmationPanel;
    private void Start()
    {
        resetConfirmationPanel.SetActive(false);
    }
    public void ResetPrefs()
    {
        resetConfirmationPanel.SetActive(true);

        
    }
    public void YesOnClick()
    {
        //PlayerPrefs.DeleteKey("Dialogue1Shown"); // Изтрива само този запис
        PlayerPrefs.DeleteAll(); // Ако искаш да изчистиш ВСИЧКО (използвай с внимание!)
        PlayerPrefs.Save();
        resetConfirmationPanel.SetActive(false);
    }
    public void NoOnClick()
    {
        resetConfirmationPanel.SetActive(false);
    }
}
