using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour
{
    //�ʿ� ���� ��������
    public GameObject gameoverGUI;

    // Start is called before the first frame update
    void Start()
    {
        gameoverGUI.SetActive(false); //ó���� ������
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGUI() //���̰� �ϴ� ����(����)
    {
        gameoverGUI.SetActive(true);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Start"); //���� �����(���� �������)
    }

    public void QuitGame() 
    {
        Application.Quit(); //���� ����
    }
}
