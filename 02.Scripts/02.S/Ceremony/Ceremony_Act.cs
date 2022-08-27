using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceremony_Act : MonoBehaviour
{
    public Animator[] all_Audience; //모든 청중 정보

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
            all_Audience[i].SetTrigger("Cheer"); //모든 관중 박수하게 하기
        }

        EndingGUI.SetActive(true); //GUI 보이게
    }
}
