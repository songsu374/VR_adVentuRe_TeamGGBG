using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
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

    public GameObject startText;
    AudioSource audioSource;
    public AudioClip startSound;
    public AudioClip deadSound;

    public int hanjoAttackCount;    //한조 맞춘 수 (0~5)

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<GameController>();
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.READY;

        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        StartCoroutine(IEnumeGameStart());
    }

    IEnumerator IEnumeGameStart()
    {
        startText.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        audioSource.PlayOneShot(startSound);

        yield return new WaitForSeconds(2.5f);

        startText.SetActive(false);

        gameState = GameState.RUN;
    }

    // 한조를 맞출때마다 한조를 공격한 횟수를 추가하고, 현재까지 공격한 한조가 몇마린지 체크
    public void CheckAttackHanjoAndCount ()
    {
        hanjoAttackCount++;

        // 한조를 공격한 수치가 5마리 이상이면
        if (hanjoAttackCount >= 5)
        {
            GameSuccess();
        }
    }

    // 게임 승리시 호출
    public void GameSuccess()
    {
        gameState = GameState.SUCCESS;
        SceneManager.LoadScene("GameClear");

    }

    // 게임 실패시 호출 (Timer.cs 에서)
    public void GameFail()
    {
        gameState = GameState.FAIL;
        SceneManager.LoadScene("GameOver");

    }
}
