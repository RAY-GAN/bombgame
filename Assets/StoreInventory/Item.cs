using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item Inventory/New Item")]
public class Item : ScriptableObject
{

    public string Itemname;
    [TextArea]
    public string Description;

    public Sprite Image;

    public int cost;
}
