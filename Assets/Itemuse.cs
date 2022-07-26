using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemuse : MonoBehaviour
{

    public PlayerInventory playeritems;
    //public GameObject opponent;
    private Player player1script;
    //private Player opponentscript;
    public GameObject ball;
    //public GameObject timercontroller;
    private Timer bombtimer;
    private List<Item> itemlist;

    // Start is called before the first frame update
    void Start()
    {
        player1script = gameObject.GetComponent<Player>();
        //opponentscript = opponent.GetComponent<Player>();
        bombtimer = GameManager.instance.bombtimer;
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
            


            if (item.Itemname == "jiasu")
            {
                bombtimer.DecreaseTargetTime(10f);
                Debug.Log("after" + bombtimer.GetLeftTime());
                
            }

            if (item.Itemname == "jiansu")
            {
                bombtimer.AddTargetTime(10f);
                Debug.Log("after" + bombtimer.GetLeftTime());

            }

            if (item.Itemname == "xianjing")
            {
                /*Vector3 position = gameObject.transform.position;
                Quaternion rotation = gameObject.transform.rotation;
                Instantiate(xianjingprefab, position, rotation);*/
                Debug.Log("used xianjing");

            }

            if (item.Itemname == "buwending")
            {
                float reTargettime = Random.Range(15f, 60f);
                bombtimer.reTargetTimer(reTargettime);
                //Text = "";
                //ball.resetable = false;
                Debug.Log("after" + bombtimer.GetLeftTime());

            }

            if (item.Itemname == "dianxue")
            {
                /* opponentscript.GetHittime += 3f;
                 ?Player????isHit????GetHittime?
                 */
            }

            if (item.Itemname == "huisu")
            {
                player1script.isTurn = false;
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 position = gameObject.transform.position;
                
                ball.transform.position = new Vector3(position.x, position.y + 1.1f, position.z);
                ball.transform.SetParent(gameObject.transform);
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.constraints = RigidbodyConstraints2D.None;

                bombtimer.reStartTimer();

            }

            if (item.Itemname == "stop")
            {
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 velocity = rb.velocity;
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.constraints = RigidbodyConstraints2D.None;
                bombtimer.pauseTimer();
                Debug.Log(bombtimer.GetLeftTime());
                StartCoroutine(WaitForSeconds(8f, rb, bombtimer, velocity));
            }


        }

    }


    public IEnumerator WaitForSeconds(float duration, Rigidbody2D rb, Timer timer, Vector3 velocity)
    {
        yield return new WaitForSeconds(duration);
        rb.AddForce(velocity,ForceMode2D.Impulse);
        timer.connitueTimer();
        Debug.Log("restarted" + timer.GetLeftTime());
    }


}


    

