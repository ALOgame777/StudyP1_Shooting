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

    // 리스트
    public List<GameObject> bullets = new List<GameObject>();
    
    // 배열
    public GameObject[] bulletArray;
    
    public int bulletCount = 10;
    public  bool useObjectPool = false;
    public bool useArray = false;

    void Start()
    {
        // AudioSource 컴포넌트를 가져오는 방법
        audioSource = transform.GetComponent<AudioSource>();
        //총알 10개를 미리 만들어서 bullets 리스트에 추가한다.
        if (useObjectPool)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bullets.Add(go);
                go.GetComponent<BulletMove>().player = gameObject;
                // 생성된 총알을 비활성화한다.
                go.SetActive(false);

                // 생성된 퐁알을 플레이어의 자식 오브젝트로 등록한다.
                go.transform.parent = transform;

            }
        }

        if (useArray)
        {
            // 배열 변수의 크기를 지정된 값으로 확장한다.
            bulletArray = new GameObject[bulletCount];
            // 배열의 각 번호에 총알 인스턴스를 생성해서 활당한다.
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bulletArray[i] = go;
                go.SetActive(false);
                go.GetComponent <BulletMove>().player = gameObject;

                // 생성된 퐁알을 플레이어의 자식 오브젝트로 등록한다.
                go.transform.parent = transform;

            }

        }
    }
        
    void Update()
        
    {
        
        #region 두개 이상 총알을 발사할 경우
            // 사용자가 마우스 왼쪽 버튼을 누르면 총알이 총구에 생성되게 하고 싶다.

            // 두개 이상 총알을 발사할 경우
            // 1. 사용자가 마우스 왼쪽 버튼을 누르는지 확인한다.
            //if (Input.GetMouseButtonDown(0))
            //{
            //    for(int i = 0; i < firePosition.Length; i++)
            //    {
            //        // 2. 총알을 생성한다.
            //        GameObject go = Instantiate(bulletPrefab);

            //        // 3. 생성된 총알을 총구로 옮긴다.
            //        go.transform.position = firePosition[i].transform.position;
            //    }

            //}
            #endregion
        
        // 1. 사용자가 마우스 왼쪽 버튼을 누르는지 확인한다.
        
        if (Input.GetMouseButtonDown(0))
        
        {
        
            if (useArray)
            {
                // 오브젝트 풀 방식(배열)으로 총알 사용
                ObjectPoolArray();
            }
        
            else if (useObjectPool)
            {
                // 오브젝트 풀 방식(리스트)으로 총알 사용
                ObjectPool();
            }
        
            if (!useObjectPool && !useArray)
            {
                //기본 방식으로 총알 사용
                InstantiateType();
            }


        
            // 총알 발사음을 실행한다.
        
            audioSource.clip = sounds[0];
            audioSource.volume = 0.2f;
            audioSource.Play();
        
            //audioSource.Stop();
        
            //audioSource.Pause();
        
        }
        
    }

        void InstantiateType()
        {
            // 2. 총알을 생성한다.
            GameObject go = Instantiate(bulletPrefab);
            // 3. 생성된 총알을 총구로 옮긴다.
            // 3-1. 총구를 게임 오브젝트 변수로 직접 지정하느 방법
            go.transform.position = firePosition.transform.position;
            go.transform.rotation = firePosition.transform.rotation;
            // 3-2. 총구를 플레이어의 위치에서 위로 1.5미터 지점을 지정하는 방법
            //Vector3 firePos = go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            //go.transform.position = firePos;
            // == go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            // 4. 생성된 총알의 BulletMove 컴포넌트에 있는 Player 변수에 자기 자신을 넣는다.
            go.GetComponent<BulletMove>().player = gameObject;
        }

        void ObjectPool()
        {
            // 0번 인덱스의 총알 오브젝트을 활성화한다.
            bullets[0].SetActive(true);
            // 활성화된 총알 오브젝트의 위치 및 회전을 총구와 일치 시킨다.
            bullets[0].transform.position = firePosition.transform.position;
            bullets[0].transform.rotation = firePosition.transform.rotation;
            
            // 활성화된 총알을 자식 오브젝트에서 해제한다.
            bullets[0].transform.parent = null;

            // 0번 인덱스의 총알을 탄창 리스트에서 제거한다.
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
                        //bulletNumber 변수 값에 해당하는 인덱스의 오브젝트를 활성화한다.
                        bulletArray[i].SetActive(true);

                        bulletArray[i].transform.position = firePosition.transform.position;
                        bulletArray[i].transform.rotation = firePosition.transform.rotation;

                        // 활성화된 총알을 자식 오브젝트에서 해제한다.
                        bulletArray[i].transform.parent = null;
                        //배열에서 해당 총알을 제거한다
                        bulletArray[i] = null;
                        break;
                        // bulletNumber의 값이 다음 번호를 지정하도록 한다
                        //bulletNumber = (i + 1) % bulletArray.Length;
                    }
                }
            }
           

        }

        //폭발 효과음을 플레이하는 함수
        public void PlayExplosionSound()
        {
            audioSource.clip = sounds[1];
            audioSource.volume = 1.0f;
            audioSource.Play();
        }
}

