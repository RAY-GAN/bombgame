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
    public int ballowner = 1;
    public int attackowner = 1;
    public GameObject BallDestroy;

    public PlayerInventory player1gold;
    public PlayerInventory player2gold;

    // Start is called before the first frame update
    void Start()
    {
        Timer timer = Timer.createTimer("Timer");
        player = transform.parent;
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            if (attackowner == 1)
            {
                player1gold.gold++;
            }
            if (attackowner == 2)
            {
                player2gold.gold++;
            }
        }
        if (collision.gameObject.CompareTag("Player1"))
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player1"), LayerMask.NameToLayer("BallTurn"), true);
            /*Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player2"), LayerMask.NameToLayer("BallTurn"), false)*/;
            Debug.Log(1);
            //Player1.GetComponent<Player>().isTurn=false;
            playerScript.isAttack = true;

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

            attackowner = 2;
            ballowner = 1;

        }
        //if (GetComponent<Player>().isTurn == false)
        //{
        //    Timer.startTiming(10, OnComplete, OnProcess);

        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}