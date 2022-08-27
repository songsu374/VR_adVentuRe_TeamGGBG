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
        READY,  // ���� ������
        RUN,    // ���� ������
        SUCCESS, // ���� �¸� ����
        FAIL    // ���� ���� ����
    }

    public GameState gameState;

    public GameObject startText;
    AudioSource audioSource;
    public AudioClip startSound;
    public AudioClip deadSound;

    public int hanjoAttackCount;    //���� ���� �� (0~5)

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

    // ������ ���⶧���� ������ ������ Ƚ���� �߰��ϰ�, ������� ������ ������ ����� üũ
    public void CheckAttackHanjoAndCount ()
    {
        hanjoAttackCount++;

        // ������ ������ ��ġ�� 5���� �̻��̸�
        if (hanjoAttackCount >= 5)
        {
            GameSuccess();
        }
    }

    // ���� �¸��� ȣ��
    public void GameSuccess()
    {
        gameState = GameState.SUCCESS;
        SceneManager.LoadScene("GameClear");

    }

    // ���� ���н� ȣ�� (Timer.cs ����)
    public void GameFail()
    {
        gameState = GameState.FAIL;
        SceneManager.LoadScene("GameOver");

    }
}
