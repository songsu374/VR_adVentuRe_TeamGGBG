using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyCat : MonoBehaviour
{
    public static EnemyCat instance;
    private void Awake()
    {
        instance = this;
    }

    public enum State
    {
        Idle,
        Move,
        Attack,
        Die,        
        Hide,
    }

    public State state;

    public GameObject PlayerTarget;
    public float speed = 1.5f;
    public float findDistance = 5f;
    public float attackDistance = 1.5f;
    float attackTime = 1f;
    float curTime;

    public ParticleSystem DieFx;
    public GameObject BeerFactory;

    NavMeshAgent agent;
    public Animator CatAnim;  //�ִϸ�����

    [SerializeField] int hitCount;  //���� Ƚ��
    public int hitMaxCount = 3;       //�ִ�� ���� Ƚ��

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        PlayerTarget = GameObject.Find("Player");
        CatAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Billboard();

        switch (state)
        {
            case State.Idle:
                CatIdle();
                break;

            case State.Move:
                CatMove();
                break;

            case State.Attack:
                CatAttack();
                break;

            case State.Die:
                CatDie();
                break;
          

            case State.Hide:
                CatHide();
                break;
               
        }
    }
    //�⺻ - ŷ�޴� ��
    private void CatIdle()
    {

        float distance = Vector3.Distance(transform.position, PlayerTarget.transform.position);

        if (Timer.instance.timeLeft > 0.5f)
        {
            if (distance < attackDistance)
            {

                state = State.Attack;
            }
            else
            {
                //���� �������� �Ÿ��� ã�� �Ÿ�����
                //�����ٸ� ���ϸ鼭 �����̱�
                if (distance < findDistance)
                {
                    state = State.Move;
                    CatAnim.SetTrigger("Move");
                }

                //�ƴ϶�� ������ �ൿ�ϱ�
                else
                {
                    state = State.Idle;
                    CatAnim.SetTrigger("Idle");
                }
            }

        }            
        else
        {
            state = State.Die;
            CatAnim.SetTrigger("Die");

        }

    }

    //������ - ���� �̵�
    private void CatMove()
    {
     
        //Ÿ���� ã�� �� �������� ���������Ѵ�.
        agent.destination = PlayerTarget.transform.position;
        //agent.SetDestination(target.transform.position);
        //�̵�:
        //1. ���� Player���� �Ÿ��� ���ϰ�
        //2. �� �Ÿ��� ���ݰ��ɰŸ����϶��(agent.stoppingDistance)
        float distance = Vector3.Distance(gameObject.transform.position, PlayerTarget.transform.position);

        if (distance <= agent.stoppingDistance)
        {
            //2.���ݻ��·� �����ϰ� �ʹ�
            state = State.Attack;

            int randomAct = Random.Range(0, 2);

            switch (randomAct)
            {
                case 0:
                    CatAnim.SetTrigger("Attack");
                    break;
                case 1:
                    CatAnim.SetTrigger("Hide");
                    break;
            }
            
            //�ִϸ��̼� ���¸� ������ ����
            CatAnim.Play("Move", 0, 0);
            //0.1�ʵ��� ���� �ִϸ��̼ǰ� �����ִϸ��̼��� ��ȯ�ض�?
            CatAnim.CrossFade("Move", 0.1f, 0);
        }
    }

    private void CatHide()
    {

        if (Timer.instance.timeLeft > 0.5f && state != State.Die)
        {
            CatAnim.SetTrigger("Hide");

            state = State.Idle;
        }
        else
        {
            state = State.Die;
            DieFx.Play();
            Destroy(this.gameObject);

        }
    }

    private void CatDie()
    {
        DieFx.transform.position = transform.position;
        DieFx.Play();

        
        Destroy(DieFx, 5f);

        Destroy(this.gameObject);

        SceneManager.LoadScene("GameOver");
        //GameObject Beer = Instantiate(BeerFactory);
        //Beer.transform.position = transform.position;

    }

    private void CatAttack()
    {
        if (Timer.instance.timeLeft>0.5f && state!=State.Die)
        {
            
           
            curTime += Time.deltaTime;
           
            if (curTime > attackTime)
            {
                curTime = 0f;
                float distance = Vector3.Distance(transform.position, PlayerTarget.transform.position);
                if (distance >= attackDistance)
                {                    
                    state = State.Move;
                    CatAnim.SetTrigger("Move");
                }
            }
        }
        else
        {
            state = State.Die;
            CatAnim.SetTrigger("Die");
            DieFx.Play();
            Destroy(this.gameObject);

            SceneManager.LoadScene("GameOver");


        }
    }


    void Billboard()
    {
        transform.LookAt(transform.position + PlayerTarget.transform.rotation * Vector3.forward, PlayerTarget.transform.rotation * Vector3.up);

        //Vector3 lookDirection = PlayerTarget.transform.position;
        //lookDirection.y = PlayerTarget.transform.position.y;
        //this.transform.LookAt(lookDirection);

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
                    CatAnim.SetTrigger("Damage");
                    hitCount = hitCount + 1;
                    Debug.Log("���� Ƚ��" + hitCount);

                }
                else if (hitCount >= hitMaxCount)
                {
                    EnemyCat.instance.state = EnemyCat.State.Die;
                    Debug.Log("����. ���� Ƚ��" + hitCount);
                    
                    DieFx.Play();
                    Destroy(this.gameObject);

                    SceneManager.LoadScene("Main");


                }
            }
            else
            {

                state = State.Die;
                DieFx.Play();
                Destroy(this.gameObject);

                SceneManager.LoadScene("GameOver");


            }
        }
    }


}
