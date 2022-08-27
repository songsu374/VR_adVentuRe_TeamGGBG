using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroyPointUI : MonoBehaviour
{

    public static DestroyPointUI instance;
    private void Awake()
    {
        instance = this;
    }
    //타겟 두더지가 죽을 때마다
    //XObj를 껐다가 켠다

    public GameObject[] xObj; //프리펩들어감
    //public GameObject molePrefap1;
    //public GameObject molePrefap2;
    //public GameObject molePrefap3;
    //public GameObject molePrefap4;
    //public GameObject molePrefap5;
    PlayerHit moleUI;
    // public int destroyMole = 5;

    void Start()
    {
        moleUI = PlayerHit.instance;
        print("UI꺼짐");
        for (int i = 0; i < xObj.Length; i++)
        {
            xObj[i].SetActive(false);
        }

        //처음엔 xObj를 전부 비활성화 한다
    }
    void IndexMole()
    {
        //만약 토탈킬카운트가 5부터 감소할때,

        //만약 totalMole이 1씩 작아지고 있다면
        //if (totalMole)
        //{
        //    xObj[a].SetActive(true);
        //    a++;
        //}
        

        for(int i=0;i < moleManager_HL.instance.killCount;i++)
        {
            xObj[i].SetActive(true);
        }


        //Invoke("IndexMole", 1f);

    }
    void Update()
    {
        IndexMole();
        if (moleManager_HL.instance.totalKillCount == moleManager_HL.instance.killCount)
        {
            SceneManager.LoadScene("Bow"); //수정해야함
        }
    }

}

