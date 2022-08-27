using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = playerTarget.transform.position;
        lookDirection.y = playerTarget.transform.position.y;
        this.transform.LookAt(lookDirection);
    }
}
