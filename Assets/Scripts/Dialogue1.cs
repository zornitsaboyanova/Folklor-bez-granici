using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] audioClips;
    public float textSpeed;

    private int index;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject dialogueBox;

    Shopska shopska;
    [SerializeField] GameObject shopskaGameObject;

    private const string dialogueKey = "Dialogue1Shown";
    void Start()
    {
        //временно изчистване докато се тества играта
        /*PlayerPrefs.DeleteKey("DialogueShown");
        PlayerPrefs.Save();*/

        if (PlayerPrefs.GetInt(dialogueKey, 0) == 1)
        {
            dialogueBox.SetActive(false); // Скриваме диалога и приключваме
            return;
        }

        PlayerPrefs.SetInt(dialogueKey, 1); // Записваме, че вече е стартирал
        PlayerPrefs.Save();

        shopska = shopskaGameObject.GetComponent<Shopska>();
        textComponent.text = string.Empty;
        StartDialogue();
        shopska.canPress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
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
                    audioSource.PlayOneShot(audioClips[index]);
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
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
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            PlayAudioClip();
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            shopska.canPress = true;
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
