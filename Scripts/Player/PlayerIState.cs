using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PlayerIState : IState
{
    public PlayerController p;

    public abstract void End();

    public abstract bool Exitable();

    public abstract void Perform();
    public abstract void Start();

}
