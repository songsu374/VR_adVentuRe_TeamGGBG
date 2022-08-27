using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PatrolAgent : MonoBehaviour
{
    public enum State
    {
        /*Idle,*/
        Patrol,
        Chase,
        Attack
    }

    public State state;

    NavMeshAgent agent;
    int index;

    float dist;
    public float maxChaseDist = 5f;
    
    public Transform chaseTarget;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Patrol;
    }

    private void Update()
    {

        dist = Vector3.Distance(this.transform.position, chaseTarget.transform.position);



        switch (state)
        {
            /*case State.Idle:
                UpdateIdle();
                break;*/

            case State.Patrol:
                UpdatePatrol();
                break;

            case State.Chase:
                UpdateChase();
                break;

            case State.Attack:
                //UpdateAttack();
                break;
        }

        //print(dist); // 
    }

    private void UpdateIdle()
    {


        // 이동상태로 전이하고 싶다.
        state = State.Patrol;
        // 애니메이션의 상태를 Move상태로 전이하고 싶다.
       // anim.SetTrigger("Move");
    }

    void UpdatePatrol()
    {
        //agent.destination = WayPointsManager.instance.list[index].position;
        //agent.destination = route[index].position;

        // 만약 도착했다면
        //float wp_distance = Vector3.Distance(transform.position, WayPointsManager.instance.list[index].position);
        //float wp_distance = Vector3.Distance(transform.position, route[index].position);
        //if (wp_distance <= agent.stoppingDistance)
        //{
        //    // index를 1 증가시키고싶다.
        //    index = (index + 1) % route.Length;
        //    //index++;
        //    //if (index >= WayPointsManager.instance.list.Length)
        //    //if (index >= route.Length)
        //    //{
        //    //    index = 0;
        //    //}
        //}

        //if (IsTargetInSight() && dist < maxEnemySight)
        //{
        //    // 추적상태로 전이하고싶다. state = State.Chase;

        //    state = State.Chase;
        //    AudioManager.instance.sfx.PlayOneShot(whistleSfx);
        //    // 추적 속도로 바꿔주고 싶다.
        //    agent.speed = 3.5f;
        //    anim.SetTrigger("Run");
        //}
    }
    private void UpdateChase()
    {
        agent.destination = chaseTarget.position;
        // chaseTarget과의 거리를 측정해서

        // 추적범위를 벗어났다면
        if (dist > maxChaseDist)
        {
            // 순찰상태로 전이하고싶다.
            state = State.Patrol;
            // 순찰속도로 바꿔주고 싶다.
            agent.speed = 2.5f;

            //anim.SetTrigger("Walk");
        }
        else
        {
            // 2.그 거리가 공격가능거리 이하라면
            if (dist <= agent.stoppingDistance)
            {
                //  공격상태로 전이하고 싶다.
                state = State.Attack;
                //anim.SetTrigger("Attack");
            }   
        }
    }



   
    public float SightAngle = 100f; //시야각 범위
   

    private void OnDrawGizmos()
    {
        // Chase 사정거리 표시
        if (state == State.Chase)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, maxChaseDist);
        }
    }
    /*  private void OnTriggerEnter(Collider other)
      {
         if(other.gameObject.name.Contains("Player")){ 

          print("1");
              state = State.Patrol;

        }
      }*/
}
