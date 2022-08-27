using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Manager_JH : MonoBehaviour
{
    public GameObject Start_UI;
    private static Game_Manager_JH _instance;

    public static Game_Manager_JH Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Game_Manager_JH>();
            }

            return _instance;
        }
    }

    public enum GameState
    {
        READY,  // ���� ������
        RUN,    // ���� ������
        SUCCESS, // ���� �¸� ����
        FAIL    // ���� ���� ����
    }

    public GameState gameState;

    //public GameObject startText;
    AudioSource audioSource;
    //public AudioClip startSound;
    //public AudioClip deadSound;

    public int Check_Money_Score;    // ȹ���� ������

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<Game_Manager_JH>();
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.RUN;
        Invoke("OnClickClose", 5f);

        //GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void GameStart()
    {
        StartCoroutine(IEnumeGameStart());
    }*/

    /*IEnumerator IEnumeGameStart()
    {
        startText.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        audioSource.PlayOneShot(startSound);

        yield return new WaitForSeconds(2.5f);

        startText.SetActive(false);

        gameState = GameState.RUN;
    }*/

    // Ÿ���� ���� ������ Money_Score�� 50�� �þ�� �ϰ�, 500�̻��� �Ǹ� ���� �¸��ϰ� ����� �ʹ�.
    public void CheckMoneyScore()
    {
        // Check_Money_Score += 50;

        // ������ ������ ��ġ�� 5���� �̻��̸�
        if (Score_Manager_JH.instance.SCORE >= 500)
        {
            GameSuccess();
            print("Game_Clear");
        }
    }

    // ���� �¸��� ȣ��
    public void GameSuccess()
    {
        gameState = GameState.SUCCESS;
        print("Game_Clear");
    }

    // ���� ���н� ȣ�� (Timer.cs ����)
    public void GameFail()
    {
        gameState = GameState.FAIL;
        print("Game_Over");
    }
    public void OnClickClose()
    {
        //print("OnClickQuit");
        Game_Manager_JH.Instance.Start_UI.SetActive(false);
    }
}