using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName ="Settings/Player")]
public class PlayerSettings : ScriptableObject
{
    public float runSpeed = 5f;
    public float health;
    public float damage;
    public float power;
    public float powerRegen;
    public float attackCost;
    public float attackRange;
    public float parryCost;
}