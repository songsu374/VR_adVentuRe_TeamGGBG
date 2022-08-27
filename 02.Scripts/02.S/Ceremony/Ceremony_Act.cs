using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceremony_Act : MonoBehaviour
{
    public Animator[] all_Audience; //��� û�� ����

    public GameObject EndingGUI;

    // Start is called before the first frame update
    void Start()
    {
        EndingGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartCeremony());
    }

    IEnumerator StartCeremony() 
    {
        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i < all_Audience.Length; i++)
        {
            all_Audience[i].SetTrigger("Cheer"); //��� ���� �ڼ��ϰ� �ϱ�
        }

        EndingGUI.SetActive(true); //GUI ���̰�
    }
}
