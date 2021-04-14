using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryState : PlayerIState
{
    public ParryState(PlayerController p)
    {
        this.p = p;
    }

    public override void End()
    {
        
    }

    public override bool Exitable()
    {
        return true;
    }

    public override void Perform()
    {
        
    }

    public override void Start()
    {
        p.anim.SetTrigger("Parry");
        p.rb.velocity = Vector2.zero;
        p.PlayAudioClip("Parry");
    }
}
