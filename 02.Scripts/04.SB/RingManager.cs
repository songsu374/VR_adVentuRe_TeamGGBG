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

    public GameObject player;       //플레이어
    public GameObject enemyCat;    //링에 있는 에너미
    public GameObject[] boxGloves; //복싱 글러브
    public GameObject boxingRing;  //복싱 링

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
