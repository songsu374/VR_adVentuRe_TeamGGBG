using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð����� �����忡�� ���� ����� ����ġ�� ��ġ(��ġ,ȸ��)�ϰ�ʹ�.
public class Enemy_Manager : MonoBehaviour
{
    public GameObject Enemy_Factory;
    public float Create_Time = 1;
    // �����ð��� �����ϰ� �ϰ�ʹ�.
    // �ּҽð�, �ִ�ð�
    public float Min_Time = 0.5f;
    public float Max_Time = 2;

    IEnumerator Start()
    {
        // 3�ʵ��� ��ٷȴٰ� ����� �����ϰ�ʹ�.
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
