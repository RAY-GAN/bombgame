using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xianjing : MonoBehaviour
{
    Rigidbody2D rb;


    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            if (collision.gameObject.CompareTag("Player1"))
            {
                player1.GetComponent<Player>().enabled = false;

                Invoke("WaitForSecondsP1", 7f);

                
            }
        
            if (collision.gameObject.CompareTag("Player2"))
            {
                player2.GetComponent<Player>().enabled = false;

                Invoke("WaitForSecondsP2", 7f);

            }
        

    }



    public void WaitForSecondsP1()
    {
        Debug.Log("dong");
        player1.GetComponent<Player>().enabled = true;
        Destroy(gameObject);
    }

    public void WaitForSecondsP2()
    {
        Debug.Log("dong");
        player2.GetComponent<Player>().enabled = true;
        Destroy(gameObject);
    }
}
