using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    Vector2 location;
    float time;
    Rigidbody2D rb;
    CreatureController c;
    float distance;

    public IdleState(Vector2 location, float time, CreatureController c)
    {
        this.location = location;
        this.time = time;
        this.rb = c.rb;
        this.c = c;
        distance = (location - rb.position).magnitude;
    }

    public void End()
    {
        c.anim.SetBool("Idle", false);
    }

    public bool Exitable()
    {
        return time <= 0;
    }

    public void Perform()
    {
        time -= time > 0 ? Time.deltaTime : 0;
    }

    public void Start()
    {
        c.anim.SetBool("Idle", true);
    }
}
