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


    //만약 플레이어가 두더지를 때렸다면
    //두더지는 파괴된다
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Mole") || collision.gameObject.CompareTag("targetMole"))
        {

            if (collision.gameObject.CompareTag("targetMole") == true)
            { //만약 파괴 된 것이 targetMole이 맞다면
              //PoseA 애니메이션이 트리거 된다
              //돈다발 이펙트가 나온다
              //소리가 나온다
                ani[0].SetTrigger("PoseA");
                MoenyVFX();
                collision.gameObject.SetActive(false);
                moleManager_HL.instance.killCount++;
                print("여기서 targetMole 파괴됨");

            }
            else if (collision.gameObject.CompareTag("Mole") == true)
            {  //만약 파괴 된것이 Mole이라면
                //PoseB 애니메이션이 트리거 된다
                //비웃음 소리가 나온다
                ani[1].SetTrigger("PoseB");
                DestroyVFX();
                collision.gameObject.SetActive(false);
                print("여기서 Mole이 파괴됨");
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
        print("소리시작");
        //theSFXManager.PlaySFX("Electric");
        print("소리끝");

    }

    //만약 플레이어와 트리거가 되지 않았다면
    //정해진 위치에서 회전한다

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
