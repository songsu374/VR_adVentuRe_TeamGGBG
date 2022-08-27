using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golf_Stick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) //때리는 부분이 무언가하고 부딧쳤을 
    {
        
        if (collision.gameObject.CompareTag("Enemy_Nor") || collision.gameObject.CompareTag("Enemy_Eli") || collision.gameObject.CompareTag("Enemy_Bos")) //걸러내기
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * -1, ForceMode.Impulse);
            //부딧친 상대를 뒤로 밀어냄
        }
    }
}
