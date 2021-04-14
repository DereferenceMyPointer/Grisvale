using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    void AddItem(Item item, float amount);

    void RemoveItem(Item item, float amount);

}
