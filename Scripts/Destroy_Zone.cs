using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ε��� Money�� �ı��ϰ� ����� �ʹ�.

public class Destroy_Zone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
