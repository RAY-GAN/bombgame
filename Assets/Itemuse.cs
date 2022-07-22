using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemuse: MonoBehaviour
{

    public PlayerInventory playeritems;
    private List<Item> itemlist;

    // Start is called before the first frame update
    void Start()
    {
        itemlist = playeritems.itemlist;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (itemlist[0] != null)
            {
                Useitem(itemlist[0]);

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemlist[1] != null)
            {
                Useitem(itemlist[1]);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemlist[2] != null)
            {
                Useitem(itemlist[2]);
            }
        }

    }


    public void Useitem(Item item)
    {
        
        if (itemlist.Remove(item))
        {
            Debug.Log("shiyongle" + item.Itemname);
        }
    }
}
