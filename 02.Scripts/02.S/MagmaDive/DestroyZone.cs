using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour
{
    public Animator[] all_cheer; //���� �迭
    AudioSource cheer_sound; //ȯȣ �Ҹ�

    public Camera afterCamera; //ĳ���� ������� 

    bool player_exist;

    // Start is called before the first frame update
    void Start()
    {
        cheer_sound = this.gameObject.GetComponent<AudioSource>();
        afterCamera.gameObject.SetActive(false); //ī�޶� ������

        player_exist = true; //ĳ���� ���� ���� ��
    }

    // Update is called once per frame
    void Update()
    {
        if (player_exist == false) //�÷��̾ ������� 
        {
            afterCamera.gameObject.SetActive(true); //ī�޶� �Ѽ�

            afterCamera.transform.Rotate(new Vector3(0, Time.deltaTime * 60, 0)); //�ʴ� 30�� ȸ��

            StartCoroutine(Za_Warudo());
        }
    }

    IEnumerator Za_Warudo() 
    {
        yield return new WaitForSeconds(6f);

        Time.timeScale = 0; //�ð� ����
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {

            for (int i = 0; i < all_cheer.Length; i++)
            {
                all_cheer[i].SetTrigger("Cheer"); //��� ���� ȯȣ�ϰ� �ϱ�

                cheer_sound.Play();//�Ҹ� ���
            }
            
            collision.gameObject.SetActive(false); //ĳ���� ������� �ϱ�
            player_exist = false; //ĳ���Ͱ� ��������� false
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {

            for (int i = 0; i < all_cheer.Length; i++)
            {
                all_cheer[i].SetTrigger("Cheer"); //��� ���� ȯȣ�ϰ� �ϱ�

                cheer_sound.Play();//�Ҹ� ���
            }

            other.gameObject.SetActive(false); //ĳ���� ������� �ϱ�
            player_exist = false; //ĳ���Ͱ� ��������� false
        }
    }

}
 