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
    //Ÿ�� �δ����� ���� ������
    //XObj�� ���ٰ� �Ҵ�

    public GameObject[] xObj; //�������
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
        print("UI����");
        for (int i = 0; i < xObj.Length; i++)
        {
            xObj[i].SetActive(false);
        }

        //ó���� xObj�� ���� ��Ȱ��ȭ �Ѵ�
    }
    void IndexMole()
    {
        //���� ��Żųī��Ʈ�� 5���� �����Ҷ�,

        //���� totalMole�� 1�� �۾����� �ִٸ�
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
            SceneManager.LoadScene("Bow"); //�����ؾ���
        }
    }

}

