using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Ball>().attackowner == 1 & gameObject.CompareTag("prepfor1"))
            {
                collision.gameObject.GetComponent<Ball>().ballowner = 1;
                GameManager.instance.bombtimer.DecreaseTargetTime(GameManager.instance.bombtimer.GetLeftTime());
            }

            if (collision.gameObject.GetComponent<Ball>().attackowner == 2 & gameObject.CompareTag("prepfor2"))
            {
                collision.gameObject.GetComponent<Ball>().ballowner = 2;
                GameManager.instance.bombtimer.DecreaseTargetTime(GameManager.instance.bombtimer.GetLeftTime());
            }

        }

        


    }
}
