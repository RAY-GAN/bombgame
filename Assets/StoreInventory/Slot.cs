using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item;

    public Image itemicon;
    
    public Text cost;

    public void start()
    {
        
    }


    public void Update()
    {
        
    }

    public void ItemOnclicked()
    {
        if (item != null)
        {
            InventoryManager.instance.UpdateItemInfo(item.Itemname + item.Description);
        }

        else return;
        
    }

   


}
