using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhuaqu : MonoBehaviour
{

    public GameObject ball;
    private Ball ballscript;
    public float grabradius;

    public bool grab;

    Vector3 ballpos;
    Vector3 zhuaqupos;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        
        ballscript = ball.GetComponent<Ball>();
        
        rb = ball.GetComponent<Rigidbody2D>();
        
        grab = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        ballpos = ball.transform.position;
        zhuaqupos = gameObject.transform.position;


        if (Vector3.Distance(ballpos,zhuaqupos) < grabradius & grab)
        {
            
            if ((gameObject.CompareTag("prepfor1") & ballscript.ballowner == 1) | (gameObject.CompareTag("prepfor2") & ballscript.ballowner == 2))
            {
                
               
                ball.transform.position = gameObject.transform.position;
                rb.velocity = Vector3.zero;
                Invoke("Release", 5f);
            }
           
        }


    }



    public void Release()
    {
        grab = false;
        // move the ball;
        if (Vector3.Distance(ballpos, zhuaqupos) > grabradius)
        {
            grab = true;
        }
        Debug.Log("released");
    }
}
