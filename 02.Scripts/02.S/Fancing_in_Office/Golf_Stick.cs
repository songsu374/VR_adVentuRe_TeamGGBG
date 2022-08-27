using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Stick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) //������ �κ��� �����ϰ� �ε����� 
    {
        
        if (collision.gameObject.CompareTag("Enemy_Nor") || collision.gameObject.CompareTag("Enemy_Eli") || collision.gameObject.CompareTag("Enemy_Bos")) //�ɷ�����
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * -1, ForceMode.Impulse);
            //�ε�ģ ��븦 �ڷ� �о
        }
    }
}
