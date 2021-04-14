using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttributes : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public bool isSpell = false;
    public GameObject spellPrefab;

    public bool depleteOnUse = true;
    public bool isAnimated = false;
    public bool useOnArmor = false;
    public string animationrigger;

    public float damage = 0;
    public float healAmount = 0;
    public float armorBuffAmount = 0;

    public float cooldown = 1f;
    public float cost;
    public float staminaCost;
}
