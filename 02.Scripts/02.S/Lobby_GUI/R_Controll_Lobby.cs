using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Controll_Lobby : MonoBehaviour
{
    bool isGrab; //������ ��� �ִ� ���� Ȯ�� ���� �� ����
    bool isTorch; //������ �����ϰ� �ִ� ���� Ȯ�� ���� �� ����

    GameObject grab_Object; // ���� �� ���� ��ü�� ������ ��� ���� ����

    public Tutorial_GUI tutorial_GUI;

    // Start is called before the first frame update
    void Start()
    {
        isGrab = false; //���𰡸� ��� ���� ����
        isTorch = false; //������ ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (isTorch == true && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isGrab = true;
            
        } //���𰡰� ������ ���¿��� Ʈ���� ��ư ������ �� ������ ���� �� + GUI Ȱ��ȭ

        if (isGrab == true && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) //A��ư�� ������ ���� ���� �޼ҵ�
        {
            //SceneManager.LoadScene(); ���� ȭ������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isGrab == false) //���� �� �ִ� ���ǿ� ���˽�
        {
            isTorch = true;//���� ��
            grab_Object = other.gameObject; //���� ��ü ������ ���� ��ü�� �ѱ�

            if (isTorch == false) //���˽� ª�� ����
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isGrab == false) //���� �� �ִ� ���ǿ� ���˽�
        {
            isTorch = false;//���� ����
            grab_Object = null; //���� ��ü ������ ����
        }
    }

    void GrabObj()
    {
        if (isTorch == true
            && isGrab == false
            && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
        {

            grab_Object.GetComponent<Rigidbody>().isKinematic = true;
            //grab_Object.transform.SetParent(grabpos); //��Ʈ�ѷ� �� grabpos�� �θ�� ����.
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
            grab_Object = null; //���� ��ü�� ������ ����
        }
    }
}
