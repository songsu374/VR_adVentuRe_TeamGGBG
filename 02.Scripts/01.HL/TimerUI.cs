using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TimerUI : MonoBehaviour
{

    public static TimerUI instance;
    private void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI timerText;
    public float timeLeft = 60f;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60f;
        timerText.text = "Timer : " + timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime * 2;

            //string minituesLeft = Mathf.FloorToInt(timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("F0");
            seconds = seconds.Length == 1 ? seconds = "0" + seconds : seconds;

            timerText.text = "Let's go to HELL : " + seconds;
        }


    }
}
