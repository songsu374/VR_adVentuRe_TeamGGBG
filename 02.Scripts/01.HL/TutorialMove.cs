using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMove : MonoBehaviour
{
    // ���� y���� �������� 30���� �¿�� ȸ���ϰ� �ʹ�

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
