using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Item Inventory/New Inventory")]
public class PlayerInventory : ScriptableObject
{

    public List<Item> itemlist = new List<Item>();

    public int gold;

}
