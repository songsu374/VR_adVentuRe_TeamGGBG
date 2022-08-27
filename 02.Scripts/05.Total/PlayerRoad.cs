using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRoad : MonoBehaviour
{
    public static PlayerRoad instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isGolf;
    public bool isBeer;
    public bool isMoney;
    public bool isHammer;
    public bool isBow;

    public GameObject[] GameOBJ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Golf"))
        {
            Debug.Log("∞Ò«¡ √Êµπ");
            collision.gameObject.SetActive(false);
            GameOBJ[0].SetActive(false);
            
            isGolf = true;
            DontDestroyOnLoad(GameOBJ[0]);
            SceneManager.LoadScene("Golf");

        }
        if (collision.gameObject.CompareTag("Beer"))
        {
            Debug.Log("∏∆¡÷");
            collision.gameObject.SetActive(false);
            GameOBJ[1].SetActive(false);


            isBeer = true;
            DontDestroyOnLoad(GameOBJ[1]);
            SceneManager.LoadScene("Beer");

        }
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("µ∑");
            collision.gameObject.SetActive(false);
            GameOBJ[2].SetActive(false);


            isMoney = true;
            DontDestroyOnLoad(GameOBJ[2]);
            SceneManager.LoadScene("Money");

        }
        if (collision.gameObject.CompareTag("Hammer"))
        {
            Debug.Log("∏¡ƒ°");
            collision.gameObject.SetActive(false);
            GameOBJ[3].SetActive(false);


            isHammer = true;
            DontDestroyOnLoad(GameOBJ[3]);
            SceneManager.LoadScene("Hammer");

        }
        if (collision.gameObject.CompareTag("Bow"))
        {
            Debug.Log("»∞");
            collision.gameObject.SetActive(false);
            GameOBJ[4].SetActive(false);

            isBow = true;
            DontDestroyOnLoad(GameOBJ[4]);
            SceneManager.LoadScene("Bow");

        }
    }
}
