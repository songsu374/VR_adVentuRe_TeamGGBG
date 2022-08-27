using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Controll_Lobby : MonoBehaviour
{
    bool isGrab; //무엇을 잡고 있는 지의 확인 여부 불 변수
    bool isTorch; //무엇과 접촉하고 있는 지의 확인 여부 불 변수

    GameObject grab_Object; // 접촉 및 잡은 객체의 정보를 얻기 위한 변수

    public Tutorial_GUI tutorial_GUI;

    // Start is called before the first frame update
    void Start()
    {
        isGrab = false; //무언가를 잡고 있지 않음
        isTorch = false; //접촉한 물건 없음
    }

    // Update is called once per frame
    void Update()
    {
        if (isTorch == true && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isGrab = true;
            
        } //무언가과 접촉한 상태에서 트리거 버튼 누르면 그 물건을 집게 됨 + GUI 활성화

        if (isGrab == true && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) //A버튼을 눌러서 게임 시작 메소드
        {
            //SceneManager.LoadScene(); 게임 화면으로
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isGrab == false) //잡을 수 있는 물건에 접촉시
        {
            isTorch = true;//접촉 됨
            grab_Object = other.gameObject; //잡은 객체 정보를 잡은 객체로 넘김

            if (isTorch == false) //접촉시 짧게 진동
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isGrab == false) //잡을 수 있는 물건에 접촉시
        {
            isTorch = false;//접촉 해지
            grab_Object = null; //잡은 객체 정보를 비우기
        }
    }

    void GrabObj()
    {
        if (isTorch == true
            && isGrab == false
            && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
        {

            grab_Object.GetComponent<Rigidbody>().isKinematic = true;
            //grab_Object.transform.SetParent(grabpos); //콘트롤러 내 grabpos를 부모로 설정.
            isGrab = true;

            tutorial_GUI.showGUI();
        }
    }

    void ReleaseObj()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true && isGrab == true)
        {
            grab_Object.transform.SetParent(null);
            isGrab = false;
            isTorch = false;
            grab_Object = null; //잡은 객체의 정보를 해지
        }
    }
}
