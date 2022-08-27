using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMole : MonoBehaviour
{
    public static DestroyMole instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject hammer;
    bool killCount;
    //플레이어의 망치에
    //닿으면 나는 파괴된다
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player") == true)
        {
            Destroy(this.gameObject);

            //만약 내가 타겟 두더지라면
            if (this.gameObject.CompareTag("targetMole"))
            {
                //killCount 1씩 오른다
                //moleManager_HL.instance.killCount += 1; //normalMole + target
                moleManager_HL.instance.totalKillCount -= 1; //targetMole

                //일반 두더지면 불구덩이로 씬로드
                if (moleManager_HL.instance.killCount == 5)
                {
                    SceneManager.LoadScene("GameClear"); //수정해야함
                }
            }
            else
            {
                if (this.gameObject.CompareTag("Mole"))
                {

                    SceneManager.LoadScene("GameOver"); //수정해야함

                }
            }
        }
    }

    void Update()
    {



    }
}
