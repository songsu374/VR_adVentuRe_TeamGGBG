using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOLEMove : MonoBehaviour
{
    // 두더지 움직임
    // 두더지들이 위 아래로 움직였으면 좋겠다
    public enum State
    {
       Idle
    }
    public State state;
    public Animator ani;
    public bool move = true;
    public Vector3 moveVector = Vector3.up;
    public float moveRange = 2.0f;
    public float moveSpeed = 2f;
    //애니메이션커브
    public AnimationCurve ac;

    private MOLEMove moleObject;

    public Vector3 startPosition;



    void Start()
    {

        moleObject = this;
        startPosition = moleObject.transform.position;
        moveVector = transform.forward;
    }

    void Update()
    {

        if (move)
        {
            moleObject.transform.position = startPosition + moveVector *
                (moveRange * Mathf.Sin(Time.timeSinceLevelLoad * moveSpeed));
        }

    }
}
