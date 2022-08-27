using TMPro;
using UnityEngine;

public class Timer_JW : MonoBehaviour
{

    public static Timer_JW instance;
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
        if (timeLeft > 0 && GameController.Instance.gameState == GameController.GameState.RUN)
        {
            timeLeft -= Time.deltaTime;

            //string minituesLeft = Mathf.FloorToInt(timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("F0");
            seconds = seconds.Length == 1 ? seconds = "0" + seconds : seconds;

            timerText.text = "Timer : " + seconds;
        }

        // 시간이 0보다 적거나 같으면
        if (timeLeft <= 0)
        {
            // 게임상태를 Fail로 변경
            GameController.Instance.GameFail();
        }
    }
}
