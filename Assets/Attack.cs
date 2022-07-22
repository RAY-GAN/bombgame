using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackPos;
    public float attackRange;
    public float attackRangeX;
    public float attackRangeY;
    public float attackRangeZ;
    Vector3 attackPoint;
    Vector3 attackWidness;
    public LayerMask whatIsPlayer;
    public Animator camAnim;
    public Animator playerAnim;
    public int time;
    public GameObject player;
    Vector3 location;

    // Start is called before the first frame update
    void Start()//获取玩家当前所在位置
    {
        location = player.transform.position;
        //(x1,y1,z1)-(x2,y2,z2)
        //Debug.Log(offset)
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion pos = transform.rotation;
        if (Input.GetKey(KeyCode.K))//按下k键位进行zoneAttack攻击判定
        {
            //camAnim.SetTrigger("shake");
            Collider[] boxToPlayer = Physics.OverlapSphere(attackPos.position, attackRange, whatIsPlayer);
            for (int i = 0; i < boxToPlayer.Length; i++)
            {
                boxToPlayer[i].GetComponent<Player>().isHit(time);
            }
        }
    }
}
