using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemuse : MonoBehaviour
{

    public PlayerInventory playeritems;
    public GameObject opponent;
    private Player player1script;
    private Player opponentscript;
    public GameObject ball;
    private Ball ballscript;
    private List<Item> itemlist;

    public GameObject bombtime;


    void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {

        gameObject.GetComponent<Itemuse>().enabled = (state == GameManager.GameState.Playing);
    }



    // Start is called before the first frame update
    void Start()
    {
        player1script = gameObject.GetComponent<Player>();
        opponentscript = opponent.GetComponent<Player>();
        ballscript = ball.GetComponent<Ball>();
        itemlist = playeritems.itemlist;

    }

    // Update is called once per frame
    void Update()
    {
        if (itemlist.Count == 0)
        {
            return;
        }

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
                GameManager.instance.bombtimer.DecreaseTargetTime(10f);
                Debug.Log("after" + GameManager.instance.bombtimer.GetLeftTime());
                
            }

            if (item.Itemname == "jiansu")
            {
                GameManager.instance.bombtimer.AddTargetTime(10f);
                Debug.Log("after" + GameManager.instance.bombtimer.GetLeftTime());

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
                GameManager.instance.bombtimer.AddTargetTime(reTargettime - GameManager.instance.bombtimer.GetLeftTime());
                ballscript.resetable = false;
                bombtime.SetActive(false);
                //Debug.Log("after" + bombtimer.GetLeftTime());

            }

            if (item.Itemname == "dianxue")
            {
                gameObject.GetComponent<Attack>().time += 3;
      
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

                GameManager.instance.bombtimer.reStartTimer();

            }

            if (item.Itemname == "stop")
            {
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 velocity = rb.velocity;
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.constraints = RigidbodyConstraints2D.None;
                GameManager.instance.bombtimer.pauseTimer();
                Debug.Log(GameManager.instance.bombtimer.GetLeftTime());
                StartCoroutine(WaitForSeconds(8f, rb, GameManager.instance.bombtimer, velocity));
            }

            if (item.Itemname == "zhuanjia")
            {
                ballscript.goldincrement1++;
            }

            if (item.Itemname == "dongzhu")
            {
                opponentscript.moveSpeed -= 3;
            }

            if (item.Itemname == "buxu")
            {
                opponentscript.rotateSpeed -= 10;
            }

            if (item.Itemname == "qifei")
            {
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                Vector3 velocity = rb.velocity;
                Vector3 direction = velocity.normalized;
                float magnitude = velocity.magnitude;
                if (ballscript.ballowner == 2)
                {
                    rb.velocity = direction * (magnitude += 5);
                }
            }


            if (item.Itemname == "wuqi")
            {
                opponent.GetComponent<Attack>().attackRange++;
            }

            if (item.Itemname == "qingna")
            {
                ballscript.zhadan2 = true;
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


    

