using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적공장에서 적을 만들고 내위치에 배치(위치,회전)하고싶다.
public class Enemy_Manager : MonoBehaviour
{
    public GameObject Enemy_Factory;
    public float Create_Time = 1;
    // 생성시간을 랜덤하게 하고싶다.
    // 최소시간, 최대시간
    public float Min_Time = 0.5f;
    public float Max_Time = 2;

    IEnumerator Start()
    {
        // 3초동안 기다렸다가 만들기 시작하고싶다.
        yield return new WaitForSeconds(3);
        while (true)
        {
            GameObject enemy = Instantiate(Enemy_Factory);
            enemy.transform.position = this.transform.position;

            yield return new WaitForSeconds(Create_Time);
            Create_Time = Random.Range(Min_Time, Max_Time);
        }
    }

    bool isFinished;
    void Update()
    {
        if (false == isFinished)
        {
            isFinished = true;
            StartCoroutine("AA");
        }
    }
    IEnumerator AA()
    {
        yield return new WaitForSeconds(1);
        isFinished = false;

    }

}
