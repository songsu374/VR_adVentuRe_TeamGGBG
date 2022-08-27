using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //GUI ����
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
            StartCoroutine(GoToLobby()); //���� ���� ȭ������ �̵��ϴ� �޼ҵ�           
        }
    }

    void OnCollisionEnter(Collision collision) //�浹��
    {
        if (collision.gameObject.CompareTag("Enemy_Nor") || collision.gameObject.CompareTag("Enemy_Eli") || collision.gameObject.CompareTag("Enemy_Bos")) //�� �ε�ġ�� ���ӿ��� �ǵ���
        {
            StartCoroutine(GoToVolcano());
        }
    }

    IEnumerator GoToVolcano() 
    {
        timer_GUI.GameOver(); 

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3.0f);


        SceneManager.LoadScene("GameOver");//���� ���� ������ �̵�
    }

    IEnumerator GoToLobby() 
    {
        timer_GUI.GameClear();

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("Main");//���� ���� ������ �̵�
    }


}
