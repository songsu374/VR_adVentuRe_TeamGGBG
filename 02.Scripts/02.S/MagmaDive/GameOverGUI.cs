using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour
{
    //필요 변수 가져오기
    public GameObject gameoverGUI;

    // Start is called before the first frame update
    void Start()
    {
        gameoverGUI.SetActive(false); //처음에 가리기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGUI() //보이게 하는 변수(연동)
    {
        gameoverGUI.SetActive(true);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Start"); //게임 재시작(이전 장면으로)
    }

    public void QuitGame() 
    {
        Application.Quit(); //게임 종료
    }
}
