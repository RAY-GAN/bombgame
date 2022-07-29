using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars_Health_Coins : MonoBehaviour
{
    public GameObject starPre, healthPre, coinPre;
    public float limitNagX, limitPosX, limitNagY, limitPosY;
    private GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            RandomInstantiate(coinPre);
        }
        RandomInstantiate(starPre);
    }

    // Update is called once per frame
    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Coin");
        if (gameObjects.Length < 3)
        {
            RandomInstantiate(coinPre);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Star");
        if (gameObjects.Length == 0)
        {
            RandomInstantiate(starPre);
        }
    }

    private void RandomInstantiate(GameObject theObject)
    {
        Instantiate(theObject, new Vector3(Random.Range(limitNagX, limitPosX), Random.Range(limitNagY, limitPosY), -0.5f), Quaternion.identity);
    }
}
