using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5;
    public float shootForce = 5f;
    public bool isTurn = false;
    public bool isAttack = false;
    public GameObject ball;
    public GameObject player1;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    public float angle = 30;
    float axisZ = 0;
    float AxisZ = 0;


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

        gameObject.GetComponent<Player>().enabled = (state == GameManager.GameState.Playing);
    }


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisZ = transform.localEulerAngles.z;
        //Debug.Log(axisZ);
        AxisZ = (float)(3.1415 * 2 * axisZ / 360);
        //Debug.Log(AxisZ);
        if (axisZ > 180)
        {
            axisZ -= 360;
        }
        Vector2 p = new Vector2(Mathf.Sin(AxisZ) * -1, Mathf.Cos(AxisZ) * 1);
        //Debug.Log(p);

        if (gameObject.CompareTag("Player1"))
        {
            float movement = Input.GetAxisRaw("Horizontal");
            float upsideDown = Input.GetAxisRaw("Vertical");
            transform.Translate(movement * moveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(0, upsideDown * moveSpeed * Time.deltaTime, 0);
            if (Input.GetKey(KeyCode.Q) && axisZ <= angle)
            {
                myTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E) && axisZ >= -angle)
            {
                myTransform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
                //Debug.Log(axisZ);
            }
        }

        else if (gameObject.CompareTag("Player2"))
        {
            float movement = Input.GetAxisRaw("Horizontal1");
            float upsideDown = Input.GetAxisRaw("Vertical1");
            transform.Translate(movement * moveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(0, upsideDown * moveSpeed * Time.deltaTime, 0);
            if (Input.GetKey(KeyCode.N) && axisZ <= angle)
            {
                myTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.M) && axisZ >= -angle)
            {
                myTransform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
                //Debug.Log(axisZ);
            }
        }




        if (!isTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ball.GetComponent<Rigidbody2D>().AddForce(p * shootForce, ForceMode2D.Impulse);
                //Debug.Log(p * shootForce);
                isTurn = true;
                transform.DetachChildren();

            }
        }

    }
    public void isHit(int time)
    {
        moveSpeed = 0;
    }
}