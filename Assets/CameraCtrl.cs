using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //(x1,y1,z1)-(x2,y2,z2)
        //Debug.Log(offset)
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;//ͨ��������Һ������λ��֮��Ĳ�ֵ���ﵽ�򵥵��������ϵͳ
    }

}