using UnityEngine;
using UnityEngine.UI;

public class Timer_GUI : MonoBehaviour
{

    //단일화
    public static Timer_GUI instance;

    private void Awake()
    {
        Timer_GUI.instance = this;
    }

    //타이머 인스턴스 생성
    float now_time; //현재 시간

    float countdown = 1f; //시간차 삭제

    //시각화
    public Text timer_text;
    public Text object_text;

    //추가사항 : 목표 제시
    public GameObject timerbox;
    public GameObject objectbox;

    public bool gameover = false;
    public bool gameclaer = false;

    public float TIMERGUI
    {
        get { return now_time; }
        set
        {
            now_time = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        objectbox.SetActive(true); //목표 보이게
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            StartGame();
        }

        if (gameover == false && gameclaer == false)
        {
            timer_text.text = "퇴근 시간까지 앞으로 " + (int)TIMERGUI + "초";
        }
    }

    public void GameClear()
    {
        gameclaer = true;

        if (gameclaer == true)
        {
            timer_text.text = "Game Clear!";
        }
    }

    public void GameOver()
    {
        gameover = true;

        if (gameover == true)
        {
            timer_text.text = "야 근 확 정";
        }

    }

    public void StartGame()
    {
        objectbox.SetActive(false); //목표 가리기
    }
}
