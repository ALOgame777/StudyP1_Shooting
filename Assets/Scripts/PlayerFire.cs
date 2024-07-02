using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;

    public AudioClip[] sounds;
    public AudioSource audioSource;
    public int bulletNumber = 0;

    // ����Ʈ
    public List<GameObject> bullets = new List<GameObject>();
    
    // �迭
    public GameObject[] bulletArray;
    
    public int bulletCount = 10;
    public  bool useObjectPool = false;
    public bool useArray = false;

    void Start()
    {
        // AudioSource ������Ʈ�� �������� ���
        audioSource = transform.GetComponent<AudioSource>();
        //�Ѿ� 10���� �̸� ���� bullets ����Ʈ�� �߰��Ѵ�.
        if (useObjectPool)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bullets.Add(go);
                go.GetComponent<BulletMove>().player = gameObject;
                // ������ �Ѿ��� ��Ȱ��ȭ�Ѵ�.
                go.SetActive(false);

                // ������ ������ �÷��̾��� �ڽ� ������Ʈ�� ����Ѵ�.
                go.transform.parent = transform;

            }
        }

        if (useArray)
        {
            // �迭 ������ ũ�⸦ ������ ������ Ȯ���Ѵ�.
            bulletArray = new GameObject[bulletCount];
            // �迭�� �� ��ȣ�� �Ѿ� �ν��Ͻ��� �����ؼ� Ȱ���Ѵ�.
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bulletArray[i] = go;
                go.SetActive(false);
                go.GetComponent <BulletMove>().player = gameObject;

                // ������ ������ �÷��̾��� �ڽ� ������Ʈ�� ����Ѵ�.
                go.transform.parent = transform;

            }

        }
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
        
            if (useArray)
            {
                // ������Ʈ Ǯ ���(�迭)���� �Ѿ� ���
                ObjectPoolArray();
            }
        
            else if (useObjectPool)
            {
                // ������Ʈ Ǯ ���(����Ʈ)���� �Ѿ� ���
                ObjectPool();
            }
        
            if (!useObjectPool && !useArray)
            {
                //�⺻ ������� �Ѿ� ���
                InstantiateType();
            }


        
            // �Ѿ� �߻����� �����Ѵ�.
        
            audioSource.clip = sounds[0];
            audioSource.volume = 0.2f;
            audioSource.Play();
        
            //audioSource.Stop();
        
            //audioSource.Pause();
        
        }
        
    }

        void InstantiateType()
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
        }

        void ObjectPool()
        {
            // 0�� �ε����� �Ѿ� ������Ʈ�� Ȱ��ȭ�Ѵ�.
            bullets[0].SetActive(true);
            // Ȱ��ȭ�� �Ѿ� ������Ʈ�� ��ġ �� ȸ���� �ѱ��� ��ġ ��Ų��.
            bullets[0].transform.position = firePosition.transform.position;
            bullets[0].transform.rotation = firePosition.transform.rotation;
            
            // Ȱ��ȭ�� �Ѿ��� �ڽ� ������Ʈ���� �����Ѵ�.
            bullets[0].transform.parent = null;

            // 0�� �ε����� �Ѿ��� źâ ����Ʈ���� �����Ѵ�.
            bullets.RemoveAt(0);
        }
        void ObjectPoolArray()
        {
            for (int i = 0; i < bulletArray.Length; i++)
            {
                if(bulletArray[i] != null)
                {
                    if (!bulletArray[i].activeInHierarchy)
                    {
                        //bulletNumber ���� ���� �ش��ϴ� �ε����� ������Ʈ�� Ȱ��ȭ�Ѵ�.
                        bulletArray[i].SetActive(true);

                        bulletArray[i].transform.position = firePosition.transform.position;
                        bulletArray[i].transform.rotation = firePosition.transform.rotation;

                        // Ȱ��ȭ�� �Ѿ��� �ڽ� ������Ʈ���� �����Ѵ�.
                        bulletArray[i].transform.parent = null;
                        //�迭���� �ش� �Ѿ��� �����Ѵ�
                        bulletArray[i] = null;
                        break;
                        // bulletNumber�� ���� ���� ��ȣ�� �����ϵ��� �Ѵ�
                        //bulletNumber = (i + 1) % bulletArray.Length;
                    }
                }
            }
           

        }

        //���� ȿ������ �÷����ϴ� �Լ�
        public void PlayExplosionSound()
        {
            audioSource.clip = sounds[1];
            audioSource.volume = 1.0f;
            audioSource.Play();
        }
}

