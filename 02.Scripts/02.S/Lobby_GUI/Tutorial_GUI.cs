using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial_GUI : MonoBehaviour
{
    //필요 변수
   

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGUI() //매개체를 잡았을 때에 보이게 하는 메소드
    {
       this.gameObject.SetActive(true);
    }


}
