using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanjoPants : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.parent.parent.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameController" && GameController.Instance.gameState == GameController.GameState.RUN)
        {
            animator.SetTrigger("DieAction");
            other.enabled = false;
            audioSource.PlayOneShot(GameController.Instance.deadSound);

            // 한조 공격시 호출
            GameController.Instance.CheckAttackHanjoAndCount();
            
        }
    }
}
