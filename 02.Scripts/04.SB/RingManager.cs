using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public static RingManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;       //�÷��̾�
    public GameObject enemyCat;    //���� �ִ� ���ʹ�
    public GameObject[] boxGloves; //���� �۷���
    public GameObject boxingRing;  //���� ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
