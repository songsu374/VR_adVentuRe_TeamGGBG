using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour
{
    public Animator[] all_cheer; //관객 배열
    AudioSource cheer_sound; //환호 소리

    public Camera afterCamera; //캐릭터 사라지고 

    bool player_exist;

    // Start is called before the first frame update
    void Start()
    {
        cheer_sound = this.gameObject.GetComponent<AudioSource>();
        afterCamera.gameObject.SetActive(false); //카메라 꺼놓기

        player_exist = true; //캐릭터 있을 때는 참
    }

    // Update is called once per frame
    void Update()
    {
        if (player_exist == false) //플레이어가 사라지면 
        {
            afterCamera.gameObject.SetActive(true); //카메라 켜서

            afterCamera.transform.Rotate(new Vector3(0, Time.deltaTime * 60, 0)); //초당 30도 회전

            StartCoroutine(Za_Warudo());
        }
    }

    IEnumerator Za_Warudo() 
    {
        yield return new WaitForSeconds(6f);

        Time.timeScale = 0; //시간 정지
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {

            for (int i = 0; i < all_cheer.Length; i++)
            {
                all_cheer[i].SetTrigger("Cheer"); //모든 관중 환호하게 하기

                cheer_sound.Play();//소리 재생
            }
            
            collision.gameObject.SetActive(false); //캐릭터 사라지게 하기
            player_exist = false; //캐릭터가 사라짐으로 false
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {

            for (int i = 0; i < all_cheer.Length; i++)
            {
                all_cheer[i].SetTrigger("Cheer"); //모든 관중 환호하게 하기

                cheer_sound.Play();//소리 재생
            }

            other.gameObject.SetActive(false); //캐릭터 사라지게 하기
            player_exist = false; //캐릭터가 사라짐으로 false
        }
    }

}
 