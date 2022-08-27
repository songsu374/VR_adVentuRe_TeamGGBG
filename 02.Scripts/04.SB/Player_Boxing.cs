using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Boxing : MonoBehaviour
{
    //만약 에너미링 이라는 태그를 가진 적이 손에있는 콜라이더와 충돌되었다면
    //충돌횟수 체크하기
    //만약 특정 시간동안 몇회이상 때렸다면
    //머슬 고양이는 점점 쭈굴려지고
    // 펑터짐
    //다시 일직선으로 달리기 나옴

    //맥주잔을 잡으면 손에 복싱장갑이 착용되고
    //착용 뒤 몇초 후 링이 위로 등장한다.

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponentInChildren<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 부모까지 같이 움직이는 스크립트
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        cc.Move((this.transform.forward * Rpos.y * Time.deltaTime * 2f));

       
        this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 50f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Beer") == true)
        {
            Invoke("OnGlove", 1f);
        }
    }

    private void OnGlove()
    {
        for (int i = 0; i < RingManager.instance.boxGloves.Length; i++)
        {
            RingManager.instance.boxGloves[i].SetActive(true);
        }
    }
}
