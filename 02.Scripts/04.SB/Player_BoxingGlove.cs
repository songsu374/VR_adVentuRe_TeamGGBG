using System.Collections;
using UnityEngine;

public class Player_BoxingGlove : MonoBehaviour
{
    [SerializeField] int hitCount;  //���� Ƚ��
    public int hitMaxCount=3;       //�ִ�� ���� Ƚ��

    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        //�տ� �ִ� ������ cat�� ��´ٸ�
        if (collision.gameObject.CompareTag("Enemy_Cat"))
        {
            Debug.Log("����̿� �浹");
            if (Timer.instance.timeLeft > 0.5f)
            {
                if (hitCount < hitMaxCount)
                {
                    hitCount = hitCount + 1;
                    Debug.Log("���� Ƚ��" + hitCount);

                }
                else if (hitCount >= hitMaxCount)
                {
                    //Enemy_Cat.instance.enemyCatState = Enemy_Cat.EnemyCatState.Die;
                    Debug.Log("���� ���� Ƚ��" + hitCount);

                }
            }
            else
            {

                //Enemy_Cat.instance.enemyCatState = Enemy_Cat.EnemyCatState.Die;
            }
        }
    }  
}
