using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHit : MonoBehaviour
{

    public static PlayerHit instance;
    private void Awake()
    {
        instance = this;
    }

    public enum State
    {
        PoseA,
        PoseB
    }
    public State state;
    public Animator[] ani;

    public GameObject moneyVFXObj;
    public GameObject destoryVFXObj;
    public GameObject thunderVFXObj;
    AudioManager theSFXManager;
    public AudioSource thunderSFX;

    public float speed = 2f;
    public GameObject hammerPosition;

    public int arraySize;
    public GameObject[] moleHit;
    void Start()
    {
        ThunderVFX();
        theSFXManager = AudioManager.instance;
    }


    //���� �÷��̾ �δ����� ���ȴٸ�
    //�δ����� �ı��ȴ�
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Mole") || collision.gameObject.CompareTag("targetMole"))
        {

            if (collision.gameObject.CompareTag("targetMole") == true)
            { //���� �ı� �� ���� targetMole�� �´ٸ�
              //PoseA �ִϸ��̼��� Ʈ���� �ȴ�
              //���ٹ� ����Ʈ�� ���´�
              //�Ҹ��� ���´�
                ani[0].SetTrigger("PoseA");
                MoenyVFX();
                collision.gameObject.SetActive(false);
                moleManager_HL.instance.killCount++;
                print("���⼭ targetMole �ı���");

            }
            else if (collision.gameObject.CompareTag("Mole") == true)
            {  //���� �ı� �Ȱ��� Mole�̶��
                //PoseB �ִϸ��̼��� Ʈ���� �ȴ�
                //����� �Ҹ��� ���´�
                ani[1].SetTrigger("PoseB");
                DestroyVFX();
                collision.gameObject.SetActive(false);
                print("���⼭ Mole�� �ı���");
            }

        }


    }
    public void MoenyVFX(float time = 0.2f)
    {
        GameObject moneyVfx = Instantiate(moneyVFXObj);
        moneyVfx.transform.position = transform.position;
        theSFXManager.PlaySFX("TargetMole");
    }
    public void DestroyVFX(float time = 0.2f)
    {
        GameObject destoyVfx = Instantiate(destoryVFXObj);
        destoyVfx.transform.position = transform.position;
        theSFXManager.PlaySFX("Laugh");
        theSFXManager.PlaySFX("Explosion");

    }
    public void ThunderVFX()
    {
        GameObject thunderVfx = Instantiate(thunderVFXObj);
        thunderVfx.transform.position = transform.position;
        print("�Ҹ�����");
        //theSFXManager.PlaySFX("Electric");
        print("�Ҹ���");

    }

    //���� �÷��̾�� Ʈ���Ű� ���� �ʾҴٸ�
    //������ ��ġ���� ȸ���Ѵ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            hammerPosition.gameObject.transform.position = this.gameObject.transform.position;
        }
        else
        { 
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));

        }
    }
    void Update()
    {

     
    }

    
}
