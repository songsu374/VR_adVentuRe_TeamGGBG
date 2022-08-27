using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Rigidbody Hanjocha1;
    public Rigidbody Hanjocha2;
    public Rigidbody Hanjocha3;
    public Rigidbody Hanjocha4;
    public Rigidbody Hanjocha5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveObject());
        
    }
    IEnumerator MoveObject()
    {
        Hanjocha1 = GetComponent<Rigidbody>();

        while(true)
        {
            float dir1 = Random.Range(-1.5f, 1.5f);
            float dir2 = Random.Range(-1.5f, 1.5f);

            yield return new WaitForSeconds(2);
            Hanjocha1.velocity = new Vector3(dir1, dir2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
