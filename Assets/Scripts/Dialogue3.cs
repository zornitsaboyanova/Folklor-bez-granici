using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    [SerializeField] GameObject dialogueBox;

    public GameObject player;
    PlayerMotor playerMotor;
    PlayerLook playerLook;

    private const string dialogueKey = "Dialogue3Shown";

    private void Start()
    {

        if (PlayerPrefs.GetInt(dialogueKey, 0) == 1)
        {
            dialogueBox.SetActive(false); // Скриваме диалога и приключваме
            //playerMotor.canMove = true;
            //playerLook.canLook = true;
            return;
        }


        playerMotor = player.GetComponent<PlayerMotor>();
        playerLook = player.GetComponent<PlayerLook>();

        playerMotor.canMove = false;
        playerLook.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        textComponent.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            PlayerPrefs.SetInt(dialogueKey, 1);
            PlayerPrefs.Save();

            playerMotor.canMove = true;
            playerLook.canLook = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
