using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{

    public float viewRange;
    public float viewAngle;
    public float patrolSpeed;

    public PatrolState(float viewRange, float viewAngle, float patrolSpeed)
    {
        this.viewRange = viewRange;
        this.viewAngle = viewAngle;
        this.patrolSpeed = patrolSpeed;
    }

    public void End()
    {
        
    }

    public bool Exitable()
    {
        return true;
    }

    public void Perform()
    {
        
    }

    public void Start()
    {
        
    }
}
