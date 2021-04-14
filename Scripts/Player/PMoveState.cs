using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public class PMoveState : PlayerIState
{
    float speed;

    public PMoveState(PlayerController p)
    {
        this.p = p;
    }

    public override void End()
    {
        p.anim.SetBool("Running", false);
    }

    public override bool Exitable()
    {
        return true;
    }

    public override void Perform()
    {
        if(p.powerLevel < p.settings.power)
        {
            p.powerLevel += Time.deltaTime * p.settings.powerRegen;
        }
        if(p.powerLevel > p.settings.power)
        {
            p.powerLevel = p.settings.power;
        }
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        p.rb.velocity = direction * p.settings.runSpeed;
        p.direction = p.rb.velocity.x;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            p.Flip();
            p.anim.SetBool("Running", true);
        } else
        {
            if(Input.GetAxisRaw("Vertical") == 0)
            {
                p.anim.SetBool("Running", false);
            } else
            {
                p.anim.SetBool("Running", true);
            }
        }
        if (Input.GetButtonDown("Fire1") && p.powerLevel >= p.settings.attackCost)
        {
            p.powerLevel -= p.settings.attackCost;
            Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Parry();
        }
        interactCast();
    }

    public override void Start()
    {
        
    }

    void Attack()
    {
        p.anim.SetTrigger("Attack");
    }

    void Parry()
    {
        if(p.settings.parryCost <= p.powerLevel)
        {
            p.powerLevel -= p.settings.parryCost;
            p.SetState(new ParryState(p));
        }
    }

    void interactCast()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(p.transform.position, (Vector3)p.Forward(), p.interactDistance, p.interactable );
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent<Interactable>(out Interactable i))
            {
                if (Input.GetButtonDown("Interact"))
                {
                    i.Interact(p);
                }
                else
                {
                    // display notifText in the interactable above the interactable
                    i.DisplayNotif();
                }
            }
        }
    }
}
