using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMove : MonoBehaviour
{
    // 나는 y축을 기준으로 30도씩 좌우로 회전하고 싶다

    public GameObject rotTitle;
    public float speed = 2f;

    void Start()
    {


    }

    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
