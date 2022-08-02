using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball") | collision.gameObject.CompareTag("Star") | collision.gameObject.CompareTag("Health")
            | collision.gameObject.CompareTag("Coin") | collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
 }
