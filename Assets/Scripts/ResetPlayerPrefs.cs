using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteKey("Dialogue1Shown"); // ������� ���� ���� �����
        PlayerPrefs.DeleteAll(); // ��� ����� �� �������� ������ (��������� � ��������!)
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs �� ��������!");
    }
}
