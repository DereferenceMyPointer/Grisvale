using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemAttributes attributes;

    public ItemCost GetCost()
    {
        return new ItemCost(attributes.depleteOnUse ? 1 : 0, attributes.staminaCost);
    }

    public ItemCost Use(GameObject source, GameObject target)
    {
        source.GetComponent<IHealth>().Heal(attributes.healAmount);
        target.GetComponent<IHealth>().Damage(attributes.damage);

        if (attributes.isSpell)
        {
            GameObject spell = GameObject.Instantiate(attributes.spellPrefab, source.transform.position, Quaternion.identity);
            // add target to spell component
        }

        return GetCost();
    }
}
