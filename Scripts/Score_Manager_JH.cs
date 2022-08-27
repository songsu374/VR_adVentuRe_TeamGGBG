using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 태어날 때 점수를 0점으로 하고 UI에도 표시하고 싶다.
// Enemy가 Bullet과 부딪혔을 때 점수를 1점 증가시키고 UI에도 표시하고 싶다.

public class Score_Manager_JH : MonoBehaviour
{
    public static Score_Manager_JH instance; // instance = null;
    private void Awake()
    {
        instance = this;  // 인스턴스라는 방 안에 이것을 넣겠다.
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
        // 태어날 때 점수를 0점으로 하고 UI에도 표시하고 싶다.
        score = 0;
        textScore.text = "Money : " + score;
    }
}

