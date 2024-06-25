using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;
    //public GameObject[] firePositions;

    //public GameObject firePosition2;


    void Start()
    {
        
    }

    void Update()
    {
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
        // 1. 사용자가 마우스 왼쪽 버튼을 누르는지 확인한다.
        if (Input.GetMouseButtonDown(0))
        {    
            // 2. 총알을 생성한다.
             GameObject go = Instantiate(bulletPrefab);

            // 3. 생성된 총알을 총구로 옮긴다.
            // 3-1. 총구를 게임 오브젝트 변수로 직접 지정하느 방법
            go.transform.position = firePosition.transform.position;
            // 3-2. 총구를 플레이어의 위치에서 위로 1.5미터 지점을 지정하는 방법
            //Vector3 firePos = go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            //go.transform.position = firePos;
            // == go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
