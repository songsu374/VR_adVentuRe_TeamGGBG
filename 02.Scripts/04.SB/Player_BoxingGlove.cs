using System.Collections;
using UnityEngine;

public class Player_BoxingGlove : MonoBehaviour
{
    [SerializeField] int hitCount;  //때린 횟수
    public int hitMaxCount=3;       //최대로 때릴 횟수

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
        //손에 있는 복싱이 cat에 닿는다면
        if (collision.gameObject.CompareTag("Enemy_Cat"))
        {
            Debug.Log("고양이와 충돌");
            if (Timer.instance.timeLeft > 0.5f)
            {
                if (hitCount < hitMaxCount)
                {
                    hitCount = hitCount + 1;
                    Debug.Log("때린 횟수" + hitCount);

                }
                else if (hitCount >= hitMaxCount)
                {
                    //Enemy_Cat.instance.enemyCatState = Enemy_Cat.EnemyCatState.Die;
                    Debug.Log("죽음 때린 횟수" + hitCount);

                }
            }
            else
            {

                //Enemy_Cat.instance.enemyCatState = Enemy_Cat.EnemyCatState.Die;
            }
        }
    }  
}
