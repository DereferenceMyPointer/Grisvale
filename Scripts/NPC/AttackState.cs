using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public CreatureController c;
    public float timeout;
    string triggerName;
    float damage;
    float hitTime;
    float hitRadius;
    float hitDuration;
    float downAngle;
    float topAngle;
    int combo;

    public AttackState(CreatureController c, float timeout, float damage, float hitTime, float hitDuration, string triggerName, float hitRadius, float downAngle, float topAngle)
    {
        this.c = c;
        this.timeout = timeout;
        combo = 0;
        this.triggerName = triggerName;
        this.damage = damage;
        this.hitTime = hitTime;
        this.hitDuration = hitDuration;
        this.hitRadius = hitRadius;
        this.downAngle = downAngle;
        this.topAngle = topAngle;
    }

    public void End()
    {
        
    }

    public bool Exitable()
    {
        return timeout <= 0;
    }

    public void Perform()
    {
        timeout -= timeout > 0 ? Time.deltaTime : 0;
        if (timeout <= 0)
        {
            if (Input.GetButton("Attack"))
                combo = 1;
            c.SetState(c.idle);
        }

    }

    private void HitFrame()
    {
        hitTime -= hitTime > 0 ? Time.deltaTime : 0;
        if(hitTime <= 0)
        {
            hitDuration -= hitDuration > 0 ? Time.deltaTime : 0;
            if(hitDuration > 0)
            {
                ExecuteDamage();
            }
        }
    }

    private void ExecuteDamage()
    {
        for(int i = 0; i < (int)downAngle; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(c.transform.position, Quaternion.AngleAxis(-downAngle / i, new Vector3(0, 0, 1)) * c.transform.forward);
            if(hit.collider.TryGetComponent<IHealth>(out IHealth health))
            {
                health.Damage(damage);
            }
        }
        for (int i = 0; i < (int)topAngle; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(c.transform.position, Quaternion.AngleAxis(topAngle / i, new Vector3(0, 0, 1)) * c.transform.forward);
            if (hit.collider.TryGetComponent<IHealth>(out IHealth health))
            {
                health.Damage(damage);
            }
        }
    }

    public void Start()
    {
        c.anim.SetTrigger(triggerName);
        // "Attack" + 0 to make different animations for combo levels inherent? Pass in trigger name string for different weaps?
    }
}
