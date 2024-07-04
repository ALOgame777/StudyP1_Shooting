using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip[] soundClip;
    AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        // ����, Ű������ ���� Ű 1���� ������
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //���� Ŭ�� �迭�� 0�� ���� ������ �����Ѵ�.
            //1. ���� ���� ����� �ҽ��� �����Ѵ�.
            ChangeSoundClip(0);
        }
        // �׷��� �ʰ� ����, Ű������ ���� Ű 2���� ������
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSoundClip(1);       
        }
        // �׷��� �ʰ� ����, Ű������ ESCŰ�� ������
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            // ����� �ҽ��� �ߴ��Ѵ�.
            musicPlayer.Stop();
        }
           

    }

    void ChangeSoundClip(int clipNumber)
    {
        //1. ���� ���� ����� �ҽ��� �����Ѵ�.
        musicPlayer.Stop();
        // 2. ���� �迭���� 0��°�� ����� �ҽ��� �ִ´�.
        musicPlayer.clip = soundClip[clipNumber];
        // 3.����� �ҽ��� �÷��� �Ѵ�.
        musicPlayer.Play();

    }
}
