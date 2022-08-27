using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerData : MonoBehaviour
{
    //최초 게임 시작 타이머
    public float timer;

    //출발 신호
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

        //자동으로 감소
        timer -= Time.deltaTime;

        if (timer < 0) 
        {
            timer = 0;
        }
    }
}
