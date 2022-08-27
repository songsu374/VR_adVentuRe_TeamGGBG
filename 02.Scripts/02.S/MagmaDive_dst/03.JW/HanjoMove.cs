using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanjoMove : MonoBehaviour
{
    Animator animator;

    public float[] waitTime;
    public float[] standingTime;
    public float[] movingTime;
    public Transform[] movingTransform;

    bool isMoving = false;
    float time;
    float speed;
    Vector3 curPos;
    Vector3 resPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Moving());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isMoving)
        {
            time += Time.deltaTime / speed;
            transform.position = Vector3.Lerp(curPos, resPos, time);
        }
        */
    }

    IEnumerator Moving()
    {
        // 이동할 좌표갯수만큼 반복
        for (int i = 0; i < movingTransform.Length; i++)
        {
            yield return new WaitForSeconds(waitTime[i]);

            //isMoving = false;

            animator.SetTrigger("anim" + (i + 1).ToString());

            yield return new WaitForSeconds(standingTime[i]);

            transform.position = movingTransform[i].position;

            /*
            isMoving = true;
            time = 0;
            speed = movingTime[i];
            curPos = transform.position;
            resPos = movingTransform[i].position;
            */

            yield return new WaitForSeconds(movingTime[i]);
        }
    }
}
