using UnityEngine;
using UnityEngine.UI;

public class Timer_GUI : MonoBehaviour
{

    //����ȭ
    public static Timer_GUI instance;

    private void Awake()
    {
        Timer_GUI.instance = this;
    }

    //Ÿ�̸� �ν��Ͻ� ����
    float now_time; //���� �ð�

    float countdown = 1f; //�ð��� ����

    //�ð�ȭ
    public Text timer_text;
    public Text object_text;

    //�߰����� : ��ǥ ����
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

        objectbox.SetActive(true); //��ǥ ���̰�
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
            timer_text.text = "��� �ð����� ������ " + (int)TIMERGUI + "��";
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
            timer_text.text = "�� �� Ȯ ��";
        }

    }

    public void StartGame()
    {
        objectbox.SetActive(false); //��ǥ ������
    }
}
