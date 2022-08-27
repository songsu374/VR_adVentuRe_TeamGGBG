using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�����ð����� ���� ����Ʈ���� �δ����� ����� �ϰ� �ʹ�

public class moleManager_HL : MonoBehaviour
{
    public static moleManager_HL instance;
    private void Awake()
    {
        instance = this;
    }

    //�δ����� �����ϰ� �߻���Ŵ
    //��Ÿ���� ���� ��ġ�� �����ϴ�
    public Transform[] spawnList;
    //public Transform sqawnPosition;
    GameObject[] moleFactory; //mole prefab ����

    //���� �ð��� ������
    public float createTime = 1;
    float currentTime;

    // �����ð��� �����ϰ� �ϰ�ʹ�.
    // �ּҽð�, �ִ�ð�
    public float minTime = 0.5f;
    public float maxTime = 2;
    int prevIndex;

    GameObject[] moles;

    public GameObject mole;
    public GameObject targetMole;

    //�δ����� �ִ� ��  => moleFactory => ok
    // �� 20����
    // �����ð����� �δ������忡�� �δ����� ����� �ʹ�


    //------moleCount----------------------------


    // ������ �δ����� ��
    public int createMaxCount = 20; // 20����
    // ������ �δ����� ��
    public int createCount;
    // �ı��� �δ����� ��
    public int killCount;
    // �ı��� �δ����� �� ��
    public int totalKillCount = 5; // 5 ����


    //------moleCount----------------------------

    void Start()
    {
        //// 3�ʵ��� ��ٷȴٰ� ����� �����ϰ�ʹ�.
        //yield return new WaitForSeconds(3);
        // Random.Range(0, 4);

        moleFactory = new GameObject[createMaxCount];
        moles = new GameObject[createMaxCount];

        for (int i = 0; i < 15; i++)
        {
            moleFactory[i] = mole;
        }
        for (int i = 0; i < 5; i++)
        {
            moleFactory[i + 15] = targetMole;
        }

        System.Random rng = new System.Random();
        List<int> sIndexes = new List<int>();

        for (int i = 0; i < createMaxCount; i++)
        {
            sIndexes.Add(i);
        }

        int n = createMaxCount;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (sIndexes[n], sIndexes[k]) = (sIndexes[k], sIndexes[n]);
        }


        for (int i = 0; i < createMaxCount; i++)
        {

            GameObject randMole = Instantiate(moleFactory[sIndexes[i]]);
            moles[i] = randMole;
            // ���� �������� �ִ���������� �۴ٸ�
            if (createCount < createMaxCount)
            {
                createCount++;
                //GameObject mole = Instantiate(moleFactory);

                // ������ Spawn����� �Ѱ�
                // 1. ������ �ε������� �����ϰ�ʹ�.
                /*
                                int index = Random.Range(0, spawnList.Length);
                                // ���� index�� ������ ������ index���
                                if (prevIndex == index)
                                {
                                    // �ٸ������� �����ϰ�ʹ�.
                                    index = (index + 1) % spawnList.Length;
                                }
                                prevIndex = index;
                */
                // 2. Spawn����� �� �ε��� ��ġ���� target���� �ϰ�ʹ�.
                randMole.transform.position = spawnList[i].position;
                randMole.transform.rotation = spawnList[i].GetChild(0).rotation;

            }
        }

        InvokeRepeating(nameof(ChangeMove), 0.0f, 2.0f);
    }

    //--------------------------------------------------------------

    // �δ��� ��ġ ����
    void ChangeMove()
    {
        System.Random rng = new System.Random();

        int n = moles.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (moles[n], moles[k]) = (moles[k], moles[n]);
        }

        for (int i = 0; i < createMaxCount; i++)
        {
            var moleMove = moles[i].GetComponent<MOLEMove>();
            moleMove.startPosition = spawnList[i].position;
            moleMove.moveVector = spawnList[i].GetChild(0).forward;
            moleMove.transform.up = spawnList[i].GetChild(0).forward;
            //print(moles[i]);
        }
    }


    //moleCount��ũ��Ʈ ����??
    void Update()
    {

    }


}