using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �¾ �� Rigidbody���� velocity�� �˷��ְ�ʹ�.
// ���� �չ������� �̵��ϰ�ʹ�.

// ���� ��� �ִ� Enemy ���� �������� �׸��� ���ư����� ����� �ʹ�.
// ���� ��� ���� ���� Enemy�� �������� �׸��� ���ư����� ����� �ʹ�.
// ���� ��� �ִ�, ��� ���� ���� Enemy ���� ������ �����ó�� ���� ������ ����� �ʹ�.

// Enemy�� �����ֱ�� �����ϰ� ����� �ʹ�.

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
