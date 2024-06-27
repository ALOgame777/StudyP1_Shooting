using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;
    //public GameObject[] firePositions;

    public AudioClip[] sounds;

    private AudioSource audioSource;


    void Start()
    {
        // AudioSource ������Ʈ�� �������� ���
        audioSource =  transform.GetComponent<AudioSource>();
        

    }

    void Update()
    {
        #region �ΰ� �̻� �Ѿ��� �߻��� ���
        // ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ��� �����ǰ� �ϰ� �ʹ�.

        // �ΰ� �̻� �Ѿ��� �߻��� ���
        // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
        //if (Input.GetMouseButtonDown(0))
        //{
        //    for(int i = 0; i < firePosition.Length; i++)
        //    {
        //        // 2. �Ѿ��� �����Ѵ�.
        //        GameObject go = Instantiate(bulletPrefab);

        //        // 3. ������ �Ѿ��� �ѱ��� �ű��.
        //        go.transform.position = firePosition[i].transform.position;
        //    }

        //}
        #endregion
        // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {    
            // 2. �Ѿ��� �����Ѵ�.
             GameObject go = Instantiate(bulletPrefab);

            // 3. ������ �Ѿ��� �ѱ��� �ű��.
            // 3-1. �ѱ��� ���� ������Ʈ ������ ���� �����ϴ� ���
            go.transform.position = firePosition.transform.position;
            go.transform.rotation = firePosition.transform.rotation;
            // 3-2. �ѱ��� �÷��̾��� ��ġ���� ���� 1.5���� ������ �����ϴ� ���
            //Vector3 firePos = go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            //go.transform.position = firePos;
            // == go.transform.position = transform.position + new Vector3(0, 1.5f, 0);

            // 4. ������ �Ѿ��� BulletMove ������Ʈ�� �ִ� Player ������ �ڱ� �ڽ��� �ִ´�.
            go.GetComponent<BulletMove>().player = gameObject;

            // �Ѿ� �߻����� �����Ѵ�.
            audioSource.clip = sounds[0];
            audioSource.volume = 0.2f;
            audioSource.Play();
            //audioSource.Stop();
            //audioSource.Pause();
        }
    }
    //���� ȿ������ �÷����ϴ� �Լ�
    public void PlayExplosionSound()
    {
        audioSource.clip = sounds[1];
        audioSource.Play();
    }
}
