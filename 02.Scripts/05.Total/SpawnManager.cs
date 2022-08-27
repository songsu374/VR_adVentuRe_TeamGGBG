using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private void Awake()
    {
        instance = this;
    }

    public static GameObject[] spawnPositions;
    //0¹ø °ñÇÁ
    //1¹ø ¸ÆÁÖ
    //2¹ø µ·
    //3¹ø ¸ÁÄ¡
    //4¹ø È°

    public static GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckPosition()
    {

        if (PlayerRoad.instance.isGolf == true &&
            PlayerRoad.instance.isBeer == false &&
            PlayerRoad.instance.isMoney == false&&
            PlayerRoad.instance.isHammer==false&&
            PlayerRoad.instance.isBow==false)
        {
            Player.transform.position= spawnPositions[0].transform.position;
            Player.transform.rotation = spawnPositions[0].transform.rotation;
        }
        else if (PlayerRoad.instance.isGolf == true &&
             PlayerRoad.instance.isBeer == true &&
             PlayerRoad.instance.isMoney == false &&
             PlayerRoad.instance.isHammer == false &&
             PlayerRoad.instance.isBow == false)
        {
            Player.transform.position = spawnPositions[1].transform.position;
            Player.transform.rotation = spawnPositions[1].transform.rotation;
        }
        else if (PlayerRoad.instance.isGolf == true &&
              PlayerRoad.instance.isBeer == true &&
              PlayerRoad.instance.isMoney == true &&
              PlayerRoad.instance.isHammer == false &&
              PlayerRoad.instance.isBow == false)
        {
            Player.transform.position = spawnPositions[2].transform.position;
            Player.transform.rotation = spawnPositions[2].transform.rotation;
        }
       else if (PlayerRoad.instance.isGolf == true &&
             PlayerRoad.instance.isBeer == true &&
             PlayerRoad.instance.isMoney == true &&
             PlayerRoad.instance.isHammer == true &&
             PlayerRoad.instance.isBow == false)
            {
            Player.transform.position = spawnPositions[3].transform.position;
            Player.transform.rotation = spawnPositions[3].transform.rotation;
        }
        else if (PlayerRoad.instance.isGolf == true &&
             PlayerRoad.instance.isBeer == true &&
             PlayerRoad.instance.isMoney == true &&
             PlayerRoad.instance.isHammer == true &&
             PlayerRoad.instance.isBow == false)
        {
            Player.transform.position = spawnPositions[4].transform.position;
            Player.transform.rotation = spawnPositions[4].transform.rotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       // collision.transform.position = spawnPositions[].position;
       // collision.transform.rotation = startPosition.rotation;
    }
}
