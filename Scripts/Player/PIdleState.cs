using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PIdleState : PlayerIState
{
    public float time;
    private float elapsed = 0;

    public PIdleState(PlayerController p, float time)
    {
        this.p = p;
        this.time = time;
    }

    public override void End()
    {
        
    }

    public override bool Exitable()
    {
        return elapsed >= time;
    }

    public override void Perform()
    {
        elapsed += elapsed < time ? Time.deltaTime : 0;
    }

    public override void Start()
    {
        p.anim.SetBool("Idle", true);
    }
}
