using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //���� ���� ����
    public GameObject deadend;
    Transform destination; //���� ������

    //�̵� AI
    NavMeshAgent pathfinder; //AI ����

    //�ִϸ��̼�
    public Animator animator;

    //����
    public AudioSource hit_sound;

    // Start is called before the first frame update
    void Start()
    {
        //�ҷ�����
        pathfinder = GetComponent<NavMeshAgent>();

        //��ǥ�� ����
        destination = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    IEnumerator UpdatePath()
    {
        while (deadend != null)
        {
            //��ǥ�� ��ġ���� ��������
            Vector3 deadPoint = new Vector3(destination.position.x, 0, destination.position.z);

            //��ǥ���� ���� ������
            pathfinder.SetDestination(deadPoint);

            //���� ��ȯ�� �ʿ� ����
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�̵� �ڷ�ƾ
        StartCoroutine(UpdatePath());
    }

    private void OnCollisionEnter(Collision collision)//�浹 �߻���
    {
        if (collision.gameObject.CompareTag("Stick"))
        {
            animator.SetTrigger("Hit"); //��Ʈ Ʈ���� �ߵ�
            hit_sound.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetTrigger("Return"); //��Ʈ Ʈ���� �ߵ�
    }
}
