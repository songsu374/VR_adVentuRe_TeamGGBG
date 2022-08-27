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


        // �̵����·� �����ϰ� �ʹ�.
        state = State.Patrol;
        // �ִϸ��̼��� ���¸� Move���·� �����ϰ� �ʹ�.
       // anim.SetTrigger("Move");
    }

    void UpdatePatrol()
    {
        //agent.destination = WayPointsManager.instance.list[index].position;
        //agent.destination = route[index].position;

        // ���� �����ߴٸ�
        //float wp_distance = Vector3.Distance(transform.position, WayPointsManager.instance.list[index].position);
        //float wp_distance = Vector3.Distance(transform.position, route[index].position);
        //if (wp_distance <= agent.stoppingDistance)
        //{
        //    // index�� 1 ������Ű��ʹ�.
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
        //    // �������·� �����ϰ�ʹ�. state = State.Chase;

        //    state = State.Chase;
        //    AudioManager.instance.sfx.PlayOneShot(whistleSfx);
        //    // ���� �ӵ��� �ٲ��ְ� �ʹ�.
        //    agent.speed = 3.5f;
        //    anim.SetTrigger("Run");
        //}
    }
    private void UpdateChase()
    {
        agent.destination = chaseTarget.position;
        // chaseTarget���� �Ÿ��� �����ؼ�

        // ���������� ����ٸ�
        if (dist > maxChaseDist)
        {
            // �������·� �����ϰ�ʹ�.
            state = State.Patrol;
            // �����ӵ��� �ٲ��ְ� �ʹ�.
            agent.speed = 2.5f;

            //anim.SetTrigger("Walk");
        }
        else
        {
            // 2.�� �Ÿ��� ���ݰ��ɰŸ� ���϶��
            if (dist <= agent.stoppingDistance)
            {
                //  ���ݻ��·� �����ϰ� �ʹ�.
                state = State.Attack;
                //anim.SetTrigger("Attack");
            }   
        }
    }



   
    public float SightAngle = 100f; //�þ߰� ����
   

    private void OnDrawGizmos()
    {
        // Chase �����Ÿ� ǥ��
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
