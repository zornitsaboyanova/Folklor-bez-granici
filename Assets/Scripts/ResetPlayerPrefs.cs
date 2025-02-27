using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteKey("Dialogue1Shown"); // Изтрива само този запис
        PlayerPrefs.DeleteAll(); // Ако искаш да изчистиш ВСИЧКО (използвай с внимание!)
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs са нулирани!");
    }
}
