using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]   // inspectorâ���� ���������ϰ� ��
public class Sound   // Sound ������ ��� �ִ� Ŭ����
{
    public string name;   // ���� �̸�
    public AudioClip clip;   // ���� mp3������ ���⿡ ������ ��
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] Sound bgm;
    [SerializeField] Sound[] sfx;

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource[] sfxPlayer;

    void Start()
    {
 
    }

    public void PlayBGM()
    {
        bgmPlayer.Play();
    }

    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    sfxPlayer[x].clip = sfx[i].clip;
                    sfxPlayer[x].Play();
                }
            }
        }
    }


    private void Update()
    {
    
    }
}
