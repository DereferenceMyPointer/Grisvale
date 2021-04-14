using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public static DialogueManager Instance;
    public bool isOpen;
    public string defaultName = "Speaking";
    public float textSpeed;
    public DialogueTrigger currentNPC;
    public PlayerController currentPlayer;
    public GameObject notifPrefab;
    private List<GameObject> notifs;
    public float notifRemoveTimeout;

    public GameObject dialoguePanel;
    public TextMeshProUGUI nameSpace;
    public TextMeshProUGUI bodySpace;
    public List<TextMeshProUGUI> dialogueOptionSpace;
    public Animator blackWash;
    public Animator deathText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();
        notifs = new List<GameObject>();
    }

    public void StartDialogue(PlayerController p, DialogueTrigger npc)
    {
        currentNPC = npc;
        isOpen = true;
        dialoguePanel.SetActive(true);
        sentences.Clear();
        foreach (string sentence in currentNPC.currentDialogue.npcText)
        {
            sentences.Enqueue(sentence);
        }
        foreach(TextMeshProUGUI t in dialogueOptionSpace)
        {
            t.text = "";
        }
        nameSpace.text = currentNPC.name;
        DisplayNext(p);
    }

    public void DisplayNext(PlayerController p)
    {
        StopAllCoroutines();
        if (sentences.Count > 0)
        {
            bodySpace.text = "";
            StartCoroutine(WriteSentences(sentences.Dequeue()));
        }
    }

    public IEnumerator WriteSentences(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            bodySpace.text += letter;
            if (letter == '.')
            {
                yield return new WaitForSeconds(textSpeed * 8);
            }
            else
            {
                yield return new WaitForSeconds(textSpeed);
            }
        }
        if(sentences.Count == 0 && currentNPC != null)
        {
            for(int i = 0; i < currentNPC.currentDialogue.next.Count; i++) {
                dialogueOptionSpace[i].text = currentNPC.currentDialogue.next[i].playerText;
            }
        }
    }

    public void EndDialogue(PlayerController p)
    {
        dialoguePanel.SetActive(false);
        isOpen = false;
        sentences.Clear();
        p.SetState(p.moveState);
    }

    public void SelectOption(int option)
    {
        currentNPC.MoveDialogue(option);
        StartDialogue(currentPlayer, currentNPC);
    }

    public void DisplayNotif(Vector3 worldLocation, string text)
    {
        // potential reimplementations like passing prefab in, running prefab's display method
        GameObject notif = Instantiate(notifPrefab, this.transform);
        notif.transform.SetParent(transform);
        notif.transform.position = Camera.main.WorldToScreenPoint(worldLocation);
        notifs.Add(notif);
        notif.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void RemoveNotifs()
    {
        foreach (GameObject notif in notifs)
        {
            Destroy(notif, notifRemoveTimeout);
        }
    }

    public void FadeToBlack(float seconds)
    {
        blackWash.SetBool("Darken", true);
        StartCoroutine(LightenTimeout(seconds));
    }

    public IEnumerator LightenTimeout(float t)
    {
        yield return new WaitForSeconds(t);
        blackWash.SetBool("Darken", false);
    }

    public void DisplayDeathText()
    {
        deathText.SetBool("Visible", true);
        StartCoroutine(DisableDeathText());
    }

    public IEnumerator DisableDeathText()
    {
        yield return new WaitForEndOfFrame();
        deathText.SetBool("Visible", false);
    }

}
