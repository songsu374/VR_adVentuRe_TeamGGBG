using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //GUI 연동
    public TimerData timerData;
    public Timer_GUI timer_GUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerData.timer <= 0 && timer_GUI != null)
        {           
            StartCoroutine(GoToLobby()); //다음 게임 화면으로 이동하는 메소드           
        }
    }

    void OnCollisionEnter(Collision collision) //충돌시
    {
        if (collision.gameObject.CompareTag("Enemy_Nor") || collision.gameObject.CompareTag("Enemy_Eli") || collision.gameObject.CompareTag("Enemy_Bos")) //적 부딧치면 게임오버 되도록
        {
            StartCoroutine(GoToVolcano());
        }
    }

    IEnumerator GoToVolcano() 
    {
        timer_GUI.GameOver(); 

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3.0f);


        SceneManager.LoadScene("GameOver");//게임 오버 씬으로 이동
    }

    IEnumerator GoToLobby() 
    {
        timer_GUI.GameClear();

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("Main");//게임 진행 씬으로 이동
    }


}
