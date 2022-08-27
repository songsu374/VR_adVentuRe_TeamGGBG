using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //적 종류
    public Enemy Mentee;
    public Enemy Mentor;
    public Enemy Boss;

    //멘토와 보스는 시간차로 출발시키기 위한 준비
    bool active_mentor; //남은 시간 2/3일 때 출발 신호
    bool active_boss; //남은 시간 1/3일 때 출발 신호

    //시간 변수 가져오기
    public TimerData timer;

    // Start is called before the first frame update
    void Start()
    {
        //둘 다 보이지 않게
        active_mentor = false;
        active_boss = false;
    }

    // Update is called once per frame
    void Update()
    {
        AddEnemy();
    }

    private void AddEnemy()
    {
        //처음에는 보이지 않게(상사)
        if (active_mentor == false)
        {
            Mentor.gameObject.SetActive(false);
        }
        else
        {
            Mentor.gameObject.SetActive(true);
        }

        if (timer.timer - timer.signal_mentor <= 0 && active_mentor == false)
        {
            active_mentor = true;
        }


        //처음에는 보이지 않게(사장)
        if (active_boss == false)
        {
            Boss.gameObject.SetActive(false);
        }
        else
        {
            Boss.gameObject.SetActive(true);
        }

        if (timer.timer - timer.signal_boss <= 0 && active_boss == false)
        {
            active_boss = true;
        }
    }
}

