using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCost
{
    public int numberUsed;
    public float staminaCost;

    public ItemCost(int numberUsed, float staminaCost)
    {
        this.numberUsed = numberUsed;
        this.staminaCost = staminaCost;
    }
}
