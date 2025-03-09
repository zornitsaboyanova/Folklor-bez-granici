using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] audioClips;
    public float textSpeed;

    private int index;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject pauseMenuCanvas;

    public GameObject player;
    PlayerMotor playerMotor;
    PlayerLook playerLook;

    private const string dialogueKey = "Dialogue3Shown";
    void Start()
    {
        pauseMenuCanvas.SetActive(false);


        if (PlayerPrefs.GetInt(dialogueKey, 0) == 1)
        {
            pauseMenuCanvas.SetActive(true);
            dialogueBox.SetActive(false); 
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

    // Update is called once per frame
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
                if (audioClips.Length > index && audioClips[index] != null)
                {
                    audioSource.Stop();
                    //audioSource.PlayOneShot(audioClips[index]);
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        //playerLook.canLook = false;
        //playerMotor.canMove = false;
        PlayAudioClip();
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
            PlayAudioClip();
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

    void PlayAudioClip()
    {
        if (audioClips.Length > index && audioClips[index] != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioClips[index]);
        }
    }
}
