using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToState : IState
{
    Vector2 location;
    float speed;
    Rigidbody2D rb;
    CreatureController c;
    float distance;

    public MoveToState(Vector2 location, float speed, CreatureController c)
    {
        this.location = location;
        this.speed = speed;
        this.rb = c.GetComponent<Rigidbody2D>();
        this.c = c;
        distance = (location - rb.position).magnitude;
    }

    public void End()
    {
        c.anim.SetBool("Running", false);
    }

    public bool Exitable()
    {
        return rb.position == location;
    }

    public void Perform()
    {
        if(Vector2.Distance(location, rb.position) < 1f / 32f)
        {
            rb.MovePosition(location);
        } else
        {
            rb.MovePosition(rb.position + (location - rb.position).normalized * Time.deltaTime * speed);
        }
    }

    public void Start()
    {
        c.anim.SetBool("Running", true);
    }
}
