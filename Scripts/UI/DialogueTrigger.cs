using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    //be sure to reimplement to be able to deal with changing progression
    public DialogueNode currentDialogue;
    public new string name;

    public Transform notifArea;
    public string notifText;

    public override void DisplayNotif()
    {
        //DialogueManager.Instance.DisplayNotif(notifArea.position, notifText);
    }

    public override void Interact(PlayerController c)
    {
        c.SetState(new DialogueState(c, this));
    }

    public void MoveDialogue(int option)
    {
        if(currentDialogue.next.Count > option)
        {
            currentDialogue = currentDialogue.next[option];
        }
    }

}
