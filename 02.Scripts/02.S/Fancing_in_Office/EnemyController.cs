using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //�� ����
    public Enemy Mentee;
    public Enemy Mentor;
    public Enemy Boss;

    //����� ������ �ð����� ��߽�Ű�� ���� �غ�
    bool active_mentor; //���� �ð� 2/3�� �� ��� ��ȣ
    bool active_boss; //���� �ð� 1/3�� �� ��� ��ȣ

    //�ð� ���� ��������
    public TimerData timer;

    // Start is called before the first frame update
    void Start()
    {
        //�� �� ������ �ʰ�
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
        //ó������ ������ �ʰ�(���)
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


        //ó������ ������ �ʰ�(����)
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

