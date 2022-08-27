using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// �¾ �� ������ 0������ �ϰ� UI���� ǥ���ϰ� �ʹ�.
// Enemy�� Bullet�� �ε����� �� ������ 1�� ������Ű�� UI���� ǥ���ϰ� �ʹ�.

public class Score_Manager_JH : MonoBehaviour
{
    public static Score_Manager_JH instance; // instance = null;
    private void Awake()
    {
        instance = this;  // �ν��Ͻ���� �� �ȿ� �̰��� �ְڴ�.
    }

    public TextMeshProUGUI textScore;

    int score;
    // property ***
    public int SCORE
    {
        get { return score; }
        set
        {
            score = value;
            textScore.text = "Money : " + score;
        }
    }

    void Start()
    {
        // �¾ �� ������ 0������ �ϰ� UI���� ǥ���ϰ� �ʹ�.
        score = 0;
        textScore.text = "Money : " + score;
    }
}

