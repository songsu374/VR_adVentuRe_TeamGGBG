using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_Cat : MonoBehaviour
{
    public static Enemy_Cat instance;

    private void Awake()
    {
        instance = this;
    }

    public enum EnemyCatState
    {
        Idle,
        //Move,
        Attack,
        Die,
        Dance,
        Hide,
    }
    public EnemyCatState enemyCatState;

    [SerializeField] Animator CatAnim;  //�ִϸ��̼�

    [SerializeField] ParticleSystem CatVFX;

    [SerializeField] int hitCount;  //���� Ƚ��
    public int hitMaxCount = 3;       //�ִ�� ���� Ƚ��


    NavMeshAgent agent = null;

    public bool isDie;

    public GameObject target;

    public float speed = 1.5f;
    public float findDistance = 5f;
    public float attackDistance = 1.5f;
    float attackTime = 1f;
    float curTime;

    public GameObject DieFxFactory;
    public GameObject BeerFactory;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        //enemyCatState = EnemyCatState.IDLE;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("IEenemyCatIdle");
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyCatState)
        {
            case EnemyCatState.Idle:
                CatIdle();
                break;

            case EnemyCatState.Dance:
                CatDance();
                break;

            case EnemyCatState.Hide:
                CatHide();
                break;

            case EnemyCatState.Attack:
                StartCoroutine("IEenemyCatAttack", 0.1f);
                break;

            case EnemyCatState.Die:
                //StartCoroutine("IEenemyCatDie", 0.1f);
                break;
        }
        //UpdateAttack();
    }

    void RandomAct()
    {
        int randomAct = Random.Range(0, 3);

        switch (randomAct)
        {
            case 0:
               enemyCatState= EnemyCatState.Idle;
                break;
            case 1:
                enemyCatState = EnemyCatState.Hide;
                break;
            case 2:
                enemyCatState = EnemyCatState.Dance;
                break;
            default:
                break;
        }

    }

    private void UpdateTarget()
    {
        //Ÿ���� ã�� �� �������� ���������Ѵ�.
        agent.destination = target.transform.position;
        //�̵�:
        //1. ���� Player���� �Ÿ��� ���ϰ�
        //2. �� �Ÿ��� ���ݰ��ɰŸ����϶��(agent.stoppingDistance)
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        if (distance <= agent.stoppingDistance)
        {
            CatAnim.SetTrigger("Attack");
            Debug.Log("����");

            StartCoroutine("IEenemyCatIdle", 3.24f);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //�տ� �ִ� ������ cat�� ��´ٸ�
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Timer.instance.timeLeft > 0.5f)
            {
                Debug.Log("����̿� �浹");
                if (hitCount < hitMaxCount)
                {
                    hitCount = hitCount + 1;
                    Debug.Log("���� Ƚ��" + hitCount);

                }
                else if (hitCount >= hitMaxCount)
                {
                    Enemy_Cat.instance.enemyCatState = Enemy_Cat.EnemyCatState.Die;
                    Debug.Log("����. ���� Ƚ��" + hitCount);


                }
            }
            else
            {

                enemyCatState = EnemyCatState.Die;
            }
        }
    }

    IEnumerator IEenemyCatIdle()
    {
        CatAnim.SetTrigger("Idle");
        Debug.Log("123");

        yield return new WaitForSeconds(2.4f);

        if (enemyCatState != EnemyCatState.Die)
        {
            int randAct = Random.Range(0, 2);
            //�������� ���������� �������ְ�ʹ�.
            switch (randAct)
            {
                //Ʈ��ŷ �߱�
                case 0:
                    //enemyCatState = EnemyCatState.DANCE;
                    StartCoroutine("IEenemyCatDance", 0.2f);
                    break;

                //���� ���ϱ�
                case 1:
                    //enemyCatState = EnemyCatState.HIDE;
                    StartCoroutine("IEenemyCatHide", 0.2f);
                    break;
            }
        }
        Debug.Log("���̵�");

        yield return null;
    }

    IEnumerator IEenemyCatAttack()
    {
        CatAnim.SetTrigger("Attack");
        Debug.Log("����");


        StartCoroutine("IEenemyCatIdle", 3.24f);
        yield return null;

    }

    IEnumerator IEenemyCatDance()
    {
        CatAnim.SetTrigger("Dancing");
        Debug.Log("��");

        StartCoroutine("IEenemyCatIdle", 3.24f);


        yield return null;
    }

    IEnumerator IEenemyCatHide()
    {
        CatAnim.SetTrigger("Hide");
        Debug.Log("���̵�");

        StartCoroutine("IEenemyCatIdle", 1.64f);

        yield return null;

    }

    IEnumerator IEenemyCatDie()
    {

        Debug.Log("����");
        CatAnim.SetTrigger("Die");

        //yield return new WaitForSeconds(2f);
        CatVFX.Play();

        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);

    }

    private void CatHide()
    {

    }

    private void CatDance()
    {
        if (Timer.instance.timeLeft < 0.5f)
        {
            Vector3 dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;
            transform.forward = dir;

            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < attackDistance)
            {

                enemyCatState = EnemyCatState.Attack;
            }
            else
            {
                //���� �������� �Ÿ��� ã�� �Ÿ�����
                //�����ٸ� ���ϸ鼭 �����̱�
                if (distance < findDistance)
                {
                    enemyCatState = EnemyCatState.Dance;
                }
                //�ƴ϶�� ������ �ൿ�ϱ�
                else
                {
                    enemyCatState = EnemyCatState.Idle;
                }
            }
        }
        else
        {
            enemyCatState = EnemyCatState.Die;

        }



    }

    private void CatDie()
    {

        GameObject DieFX = Instantiate(DieFxFactory);
        DieFX.transform.position = transform.position;
        Destroy(DieFX, 5f);

        Destroy(this.gameObject);
        //GameObject Beer = Instantiate(BeerFactory);
        //Beer.transform.position = transform.position;

    }

    private void CatAttack()
    {
        if (Timer.instance.timeLeft > 0.5f && enemyCatState != EnemyCatState.Die)
        {


            curTime += Time.deltaTime;
            //2. ?????????? ?????????? ????
            if (curTime > attackTime)
            {
                curTime = 0f;
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance >= attackDistance)
                {

                    enemyCatState = EnemyCatState.Dance;
                }
            }
        }
        else
        {
            enemyCatState = EnemyCatState.Die;
        }
    }

    //�⺻ - �� ����, ������
    private void CatIdle()
    {
        UpdateTarget();
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < findDistance)
        {
            enemyCatState = EnemyCatState.Dance;
        }
    }
}

