using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //도달 지점 설정
    public GameObject deadend;
    Transform destination; //최종 목적진

    //이동 AI
    NavMeshAgent pathfinder; //AI 정보

    //애니메이션
    public Animator animator;

    //음성
    public AudioSource hit_sound;

    // Start is called before the first frame update
    void Start()
    {
        //불러오기
        pathfinder = GetComponent<NavMeshAgent>();

        //목표물 설정
        destination = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    IEnumerator UpdatePath()
    {
        while (deadend != null)
        {
            //목표물 위치정보 가져오기
            Vector3 deadPoint = new Vector3(destination.position.x, 0, destination.position.z);

            //목표물이 최종 목적지
            pathfinder.SetDestination(deadPoint);

            //딱히 반환할 필요 없음
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //이동 코루틴
        StartCoroutine(UpdatePath());
    }

    private void OnCollisionEnter(Collision collision)//충돌 발생시
    {
        if (collision.gameObject.CompareTag("Stick"))
        {
            animator.SetTrigger("Hit"); //히트 트리거 발동
            hit_sound.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetTrigger("Return"); //히트 트리거 발동
    }
}
