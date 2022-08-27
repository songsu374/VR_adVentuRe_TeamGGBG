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
    public Animator CatAnim;  //애니메이터

    [SerializeField] int hitCount;  //때린 횟수
    public int hitMaxCount = 3;       //최대로 때릴 횟수

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
    //기본 - 킹받는 댄스
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
                //만약 적과와의 거리가 찾는 거리보다
                //가깝다면 댄스하면서 움직이기
                if (distance < findDistance)
                {
                    state = State.Move;
                    CatAnim.SetTrigger("Move");
                }

                //아니라면 술취한 행동하기
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

    //움직임 - 권투 이동
    private void CatMove()
    {
     
        //타겟을 찾은 후 목적지로 움직여야한다.
        agent.destination = PlayerTarget.transform.position;
        //agent.SetDestination(target.transform.position);
        //이동:
        //1. 나와 Player와의 거리를 구하고
        //2. 그 거리가 공격가능거리이하라면(agent.stoppingDistance)
        float distance = Vector3.Distance(gameObject.transform.position, PlayerTarget.transform.position);

        if (distance <= agent.stoppingDistance)
        {
            //2.공격상태로 전이하고 싶다
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
            
            //애니메이션 상태를 강제로 시작
            CatAnim.Play("Move", 0, 0);
            //0.1초동안 지금 애니메이션과 다음애니메이션을 변환해라?
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
        //손에 있는 복싱이 cat에 닿는다면
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Timer.instance.timeLeft > 0.5f)
            {
                Debug.Log("고양이와 충돌");
                if (hitCount < hitMaxCount)
                {
                    CatAnim.SetTrigger("Damage");
                    hitCount = hitCount + 1;
                    Debug.Log("때린 횟수" + hitCount);

                }
                else if (hitCount >= hitMaxCount)
                {
                    EnemyCat.instance.state = EnemyCat.State.Die;
                    Debug.Log("죽음. 때린 횟수" + hitCount);
                    
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
