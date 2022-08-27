using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �¾ �� Rigidbody���� velocity�� �˷��ְ�ʹ�.
// ���� �չ������� �̵��ϰ�ʹ�.

// ���� ��� �ִ� Enemy ���� �������� �׸��� ���ư����� ����� �ʹ�.
// ���� ��� ���� ���� Enemy�� �������� �׸��� ���ư����� ����� �ʹ�.
// ���� ��� �ִ�, ��� ���� ���� Enemy ���� ������ �����ó�� ���� ������ ����� �ʹ�.

// Enemy�� �����ֱ�� �����ϰ� ����� �ʹ�.

public class Enemy_JH : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20;

    // �����Ҷ� �ð�ȿ���� �ְ�ʹ�.
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
