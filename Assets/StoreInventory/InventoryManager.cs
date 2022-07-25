using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;


    public PlayerInventory player1item;
    public PlayerInventory player2item;
    public PlayerInventory all;

    private bool player1ready;
    private bool player2ready;

    

    public List<Item> saleitems= new List<Item>();

    public GameObject itemgrid;

    public GameObject player1itemgrid;

    public GameObject player2itemgrid;

    public Text iteminfo;
    public Text player1gold;
    public Text player2gold;


    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }


    private void OnEnable()
    {
        instance.iteminfo.text = "";
        
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(state == GameManager.GameState.Store);
    }



    public void UpdateItemInfo(string itemdescription)
    {
        instance.iteminfo.text = itemdescription;
    }

    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            int index = Random.Range(0,all.itemlist.Count);

            while (saleitems.Contains(all.itemlist[index]))
            {
                index = Random.Range(0, all.itemlist.Count);
            }

            saleitems.Add(all.itemlist[index]);
        }



        for (int i = 0; i < itemgrid.transform.childCount; i++)
        {
            GameObject grid = itemgrid.transform.GetChild(i).gameObject;

            Item item = saleitems[i];

            Slot slot = grid.GetComponent<Slot>();

            slot.item  = item;
            slot.itemicon.sprite = item.Image;
            slot.cost.text = item.cost.ToString();

        }


        for (int i = 0; i < player1item.itemlist.Count; i++)
        {
            GameObject grid = player1itemgrid.transform.GetChild(i).gameObject;
            

            Item item = player1item.itemlist[i];
            

            Slot slot = grid.GetComponent<Slot>();

            slot.item = item;
            slot.itemicon.sprite = item.Image;
            slot.cost.text = item.cost.ToString();

    
        }


        for (int i = 0; i < player2item.itemlist.Count; i++)
        {
            GameObject grid = player2itemgrid.transform.GetChild(i).gameObject;

            Item item = player2item.itemlist[i];
            

            Slot slot = grid.GetComponent<Slot>();

            slot.item = item;
            slot.itemicon.sprite = item.Image;
            slot.cost.text = item.cost.ToString();

        }


    }


    public void Update()
    {
        instance.player1gold.text = player1item.gold.ToString();
        instance.player2gold.text = player2item.gold.ToString();
    }

    public static bool AddItem(Item item, PlayerInventory playeritems)
    {
        if (!playeritems.itemlist.Contains(item) & item.cost < playeritems.gold)
        {
            playeritems.itemlist.Add(item);
            playeritems.gold -= item.cost;
            return true;
        }

        else if (item.cost > playeritems.gold)
        {
            Debug.Log("jinbibuzu");
            return false;
        }

        else 
        {
            Debug.Log("shengji");
            return false;
        }
    }



    public static void RefundItem(Item item, PlayerInventory playeritems)
    {
        if (playeritems.itemlist.Remove(item))
        {
            
            playeritems.gold += item.cost;
        }
        
    }


}
