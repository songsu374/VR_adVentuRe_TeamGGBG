using TMPro;
using UnityEngine;

public class Timer_JH : MonoBehaviour
{

    public static Timer_JH instance;
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
        if (timeLeft > 0 && Game_Manager_JH.Instance.gameState == Game_Manager_JH.GameState.RUN)
        {
            timeLeft -= Time.deltaTime;
            //timeLeft -= Time.deltaTime * 2;

            //string minituesLeft = Mathf.FloorToInt(timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("F0");
            seconds = seconds.Length == 1 ? seconds = "0" + seconds : seconds;

            timerText.text = "Timer : " + seconds;
        }

        // �ð��� 0���� ���ų� ������
        if (timeLeft <= 0)
        {
            // ���ӻ��¸� Fail�� ����
            Game_Manager_JH.Instance.GameFail();
            print("Game_Over");
        }
    }
}










/*using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static Timer instance;
    private void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI timerText;
    public float timeLeft = 30f;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 30f;
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

            timerText.text = "Timer : " + seconds;
        }


    }
}*/