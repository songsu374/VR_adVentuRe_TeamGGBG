using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial_GUI : MonoBehaviour
{
    //�ʿ� ����
   

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGUI() //�Ű�ü�� ����� ���� ���̰� �ϴ� �޼ҵ�
    {
       this.gameObject.SetActive(true);
    }


}
