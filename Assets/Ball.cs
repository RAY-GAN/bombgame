using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public Player playerScript;
    public GameObject Player1;
    public GameObject Player2;
    private LayerMask ballTurn;
    public int ballowner = 2;
    public int attackowner = 1;
    public int goldincrement1 = 1;
    public int goldincrement2 = 1;

    public float bombtime;

    public bool resetable = true;
    public bool zhadan1 = false;
    public bool zhadan2 = false;

    public GameObject BallDestroy;

    public PlayerInventory player1gold;
    public PlayerInventory player2gold;



    // Start is called before the first frame update
    void Start()
    {
        Timer timer = Timer.createTimer("Timer");
        player = transform.parent;
        rb = GetComponent<Rigidbody2D>();
        bombtime = GameManager.instance.bombtime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnComplete()
    {
        Debug.Log("complete!");
        Destroy(BallDestroy);
    }    //????????????
    void OnProcess(float p)
    {
        //Debug.Log("on process" + p);
    }
    //???????????
    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (zhadan1 & ballowner == 1)
        {
            GameManager.instance.bombtimer.DecreaseTargetTime(3f);
        }

        if (zhadan2 & ballowner == 2)
        {
            GameManager.instance.bombtimer.DecreaseTargetTime(3f);
        }


        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            if (attackowner == 1)
            {
                player1gold.gold += goldincrement1;
            }
            if (attackowner == 2)
            {
                player2gold.gold += goldincrement2;
            }
        }

        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            if (attackowner == 1)
            {
                player1gold.gold += (3 + goldincrement1);
            }
            if (attackowner == 2)
            {
                player2gold.gold += (3 + goldincrement1);
            }
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            if (attackowner == 1)
            {
                //Player1.GetComponent<Player>().health--;
            }
            if (attackowner == 2)
            {
                //Player2.GetComponent<Player>().health--;
            }
        }



        if (collision.gameObject.CompareTag("Player1"))
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player1"), LayerMask.NameToLayer("BallTurn"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("BallTurn"), false);
            Debug.Log(1);
            //Player1.GetComponent<Player>().isTurn=false;
            playerScript.isAttack = true;


            Resetbomb();


            attackowner = 1;
            ballowner = 2;

        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player1"), LayerMask.NameToLayer("BallTurn"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("BallTurn"), true);
            Debug.Log(2);
            playerScript.isTurn = false;
            playerScript.isAttack = true;

            Resetbomb();


            attackowner = 2;
            ballowner = 1;

        }
        //if (GetComponent<Player>().isTurn == false)
        //{
        //    Timer.startTiming(10, OnComplete, OnProcess);

        //}
    }

    private void Resetbomb()
    {
        if (resetable)
        {
            float shrinktime = UnityEngine.Random.Range(1f, 5f);
            bombtime -= shrinktime;
            if (bombtime < 7f)
            {
                bombtime = 7f;
            }
            GameManager.instance.bombtimer.AddTargetTime(bombtime - GameManager.instance.bombtimer.GetLeftTime());
            Debug.Log(bombtime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}