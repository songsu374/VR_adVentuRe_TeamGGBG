using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerData : MonoBehaviour
{
    //���� ���� ���� Ÿ�̸�
    public float timer;

    //��� ��ȣ
    public float signal_mentor;
    public float signal_boss;

    // Start is called before the first frame update
    void Start()
    {
        signal_mentor = (timer / 3) * 2;
        signal_boss = (timer / 3);
    }

    // Update is called once per frame
    void Update()
    {
        Timer_GUI.instance.TIMERGUI = timer;

        //�ڵ����� ����
        timer -= Time.deltaTime;

        if (timer < 0) 
        {
            timer = 0;
        }
    }
}
