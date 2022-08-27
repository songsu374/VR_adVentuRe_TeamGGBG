using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날 때 Rigidbody에게 velocity를 알려주고싶다.
// 나의 앞방향으로 이동하고싶다.

// 돈을 들고 있는 Enemy 들을 포물선을 그리며 날아가도록 만들고 싶다.
// 돈을 들고 있지 않은 Enemy도 포물선을 그리며 날아가도록 만들고 싶다.
// 돈을 들고 있는, 들고 있지 않은 Enemy 들이 벽에서 장우혁처럼 빼꼼 나오게 만들고 싶다.

// Enemy를 일정주기로 등장하게 만들고 싶다.

public class Enemy_JH : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20;

    // 폭발할때 시각효과를 넣고싶다.
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.AddTorque(transform.right * speed);
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
