using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Boxing : MonoBehaviour
{
    //���� ���ʹ̸� �̶�� �±׸� ���� ���� �տ��ִ� �ݶ��̴��� �浹�Ǿ��ٸ�
    //�浹Ƚ�� üũ�ϱ�
    //���� Ư�� �ð����� ��ȸ�̻� ���ȴٸ�
    //�ӽ� ����̴� ���� �ޱ�������
    // ������
    //�ٽ� ���������� �޸��� ����

    //�������� ������ �տ� �����尩�� ����ǰ�
    //���� �� ���� �� ���� ���� �����Ѵ�.

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponentInChildren<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �θ���� ���� �����̴� ��ũ��Ʈ
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        cc.Move((this.transform.forward * Rpos.y * Time.deltaTime * 2f));

       
        this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 50f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Beer") == true)
        {
            Invoke("OnGlove", 1f);
        }
    }

    private void OnGlove()
    {
        for (int i = 0; i < RingManager.instance.boxGloves.Length; i++)
        {
            RingManager.instance.boxGloves[i].SetActive(true);
        }
    }
}
