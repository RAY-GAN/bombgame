using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tabmanager : MonoBehaviour
{

    public Text Score1;
    public Text Score2;
    public Text Time;
    public Text player1gold;
    public Text player2gold;

    public PlayerInventory player1item;
    public PlayerInventory player2item;

    public GameObject player1itemgrid;

    public GameObject player2itemgrid;

    private GameObject tabpanel;

    // Start is called before the first frame update
    void Start()
    {

        tabpanel = gameObject.transform.GetChild(0).gameObject;



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tabpanel.SetActive(!tabpanel.activeSelf);
        }




        if (player1item.itemlist.Count == player1itemgrid.transform.childCount)
        {
            for (int i = 0; i < player1itemgrid.transform.childCount; i++)
            {

                GameObject grid = player1itemgrid.transform.GetChild(i).gameObject;


                Item item = player1item.itemlist[i];


                Slot slot = grid.GetComponent<Slot>();

                slot.item = item;
                slot.itemicon.sprite = item.Image;
                slot.cost.text = item.cost.ToString();
            }

        }

         else if (player1item.itemlist.Count < player1itemgrid.transform.childCount)
        {
            for (int i = 0; i < player1item.itemlist.Count; i++)
            {

                GameObject grid = player1itemgrid.transform.GetChild(i).gameObject;


                Item item = player1item.itemlist[i];


                Slot slot = grid.GetComponent<Slot>();

                slot.item = item;
                slot.itemicon.sprite = item.Image;
                slot.cost.text = item.cost.ToString();
            }

            for (int i = player1item.itemlist.Count; i < player1itemgrid.transform.childCount; i++)
            {
                GameObject grid = player1itemgrid.transform.GetChild(i).gameObject;


                Slot slot = grid.GetComponent<Slot>();

                slot.item = null;
                slot.itemicon.sprite = null;
                slot.cost.text = "";
            }
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

        player1gold.text = player1item.gold.ToString();
        player2gold.text = player2item.gold.ToString();


    }
}
