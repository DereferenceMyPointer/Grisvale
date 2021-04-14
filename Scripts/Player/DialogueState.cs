using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : PlayerIState
{
    public DialogueTrigger npc;
    bool exitable = false;

    public DialogueState(PlayerController p, DialogueTrigger npc)
    {
        this.npc = npc;
        this.p = p;
    }

    public override void End()
    {
        
    }

    public override bool Exitable()
    {
        return exitable;
    }

    public override void Perform()
    {
        if (Input.GetButtonDown("Escape"))
        {
            exitable = true;
            DialogueManager.Instance.EndDialogue(p);
        }
    }   

    public override void Start()
    {
        DialogueManager.Instance.StartDialogue(p, npc);
    }
}
