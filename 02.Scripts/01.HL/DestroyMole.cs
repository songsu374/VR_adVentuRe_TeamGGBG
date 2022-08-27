using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMole : MonoBehaviour
{
    public static DestroyMole instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject hammer;
    bool killCount;
    //�÷��̾��� ��ġ��
    //������ ���� �ı��ȴ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player") == true)
        {
            Destroy(this.gameObject);

            //���� ���� Ÿ�� �δ������
            if (this.gameObject.CompareTag("targetMole"))
            {
                //killCount 1�� ������
                //moleManager_HL.instance.killCount += 1; //normalMole + target
                moleManager_HL.instance.totalKillCount -= 1; //targetMole

                //�Ϲ� �δ����� �ұ����̷� ���ε�
                if (moleManager_HL.instance.killCount == 5)
                {
                    SceneManager.LoadScene("GameClear"); //�����ؾ���
                }
            }
            else
            {
                if (this.gameObject.CompareTag("Mole"))
                {

                    SceneManager.LoadScene("GameOver"); //�����ؾ���

                }
            }
        }
    }

    void Update()
    {



    }
}
