using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public PlayerController p;
    public Animator effects;

    public void PunchHit()
    {
        p.PunchHit();
        effects.SetTrigger("Play");
        p.PlayAudioClip("Punch");
    }

    public void ParryStart()
    {
        effects.SetTrigger("Parry");
        p.immune = true;
    }

    public void ParryEnd()
    {
        p.immune = false;
        p.SetState(p.moveState);
    }

}
