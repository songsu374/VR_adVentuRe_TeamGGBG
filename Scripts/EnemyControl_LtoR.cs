using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 태어날 때 Rigidbody에게 velocity를 알려주고싶다.
// 나의 앞방향으로 이동하고싶다.

// 돈을 들고 있는 Enemy 들을 포물선을 그리며 날아가도록 만들고 싶다.
// 돈을 들고 있지 않은 Enemy도 포물선을 그리며 날아가도록 만들고 싶다.
// 돈을 들고 있는, 들고 있지 않은 Enemy 들이 벽에서 장우혁처럼 빼꼼 나오게 만들고 싶다.

// Enemy를 일정주기로 등장하게 만들고 싶다.

public class EnemyControl_LtoR : MonoBehaviour
{
    public float Speed = 50.0f;
    public float Spin_Speed = 200;
    private Transform My_Transform = null;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        My_Transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.right * Spin_Speed);
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = Speed * Vector3.right * Time.deltaTime;
        My_Transform.Translate(moveAmount);



        //if (myTransform.position.y <= -60.0f)
        //{
        //    myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 60.0f, 0.0f);
        //}
    }
}
