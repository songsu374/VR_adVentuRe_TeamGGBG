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
        READY,  // 게임 시작전
        RUN,    // 게임 실행중
        SUCCESS, // 게임 승리 상태
        FAIL    // 게임 실패 상태
    }

    public GameState gameState;

    //public GameObject startText;
    AudioSource audioSource;
    //public AudioClip startSound;
    //public AudioClip deadSound;

    public int Check_Money_Score;    // 획득한 돈점수

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

    // 타겟을 맞출 때마다 Money_Score가 50씩 늘어나게 하고, 500이상이 되면 게임 승리하게 만들고 싶다.
    public void CheckMoneyScore()
    {
        // Check_Money_Score += 50;

        // 한조를 공격한 수치가 5마리 이상이면
        if (Score_Manager_JH.instance.SCORE >= 500)
        {
            GameSuccess();
            print("Game_Clear");
        }
    }

    // 게임 승리시 호출
    public void GameSuccess()
    {
        gameState = GameState.SUCCESS;
        print("Game_Clear");
    }

    // 게임 실패시 호출 (Timer.cs 에서)
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