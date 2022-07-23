using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemuse : MonoBehaviour
{

    public PlayerInventory playeritems;
    //public GameObject opponent;
    private Player playerscript;
    //private Player opponentscript;
    public GameObject ball;
    public Publictimer timerscript;
    private Timer publictimer;
    private List<Item> itemlist;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = gameObject.GetComponent<Player>();
        //opponentscript = opponent.GetComponent<Player>();
        publictimer = timerscript.publictimer;
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
            Debug.Log(publictimer.GetLeftTime());


            if (item.Itemname == "jiasu")
            {
                publictimer.DecreaseTargetTime(10f);
                Debug.Log("after" + publictimer.GetLeftTime());
                
            }

            if (item.Itemname == "jiansu")
            {
                publictimer.AddTargetTime(10f);
                Debug.Log("after" + publictimer.GetLeftTime());

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
                publictimer.reTargetTimer(reTargettime);
                //Text = "";
                //ball.resetable = false;
                Debug.Log("after" + publictimer.GetLeftTime());

            }

            if (item.Itemname == "dianxue")
            {
                /* opponentscript.GetHittime += 3f;
                 ?Player????isHit????GetHittime?
                 */
            }

            if (item.Itemname == "huisu")
            {
                playerscript.isTurn = false;
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 position = gameObject.transform.position;
                
                ball.transform.position = new Vector3(position.x, position.y + 1.1f, position.z);
                ball.transform.SetParent(gameObject.transform);
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.constraints = RigidbodyConstraints2D.None;

                publictimer.reStartTimer();

            }

            if (item.Itemname == "stop")
            {
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 velocity = rb.velocity;
                rb.bodyType = RigidbodyType2D.Static;
                publictimer.pauseTimer();
                StartCoroutine(WaitForSeconds(8f, rb, publictimer, velocity));
            }


        }

    }


    public static IEnumerator WaitForSeconds(float duration, Rigidbody2D rb, Timer timer, Vector3 velocity)
    {
        yield return new WaitForSeconds(duration);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(velocity,ForceMode2D.Impulse);
        timer.connitueTimer();
        Debug.Log("restarted");
    }


}


    

