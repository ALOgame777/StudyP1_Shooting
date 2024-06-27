using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // 지정된 확률에 따라 아래로 또는 플레이어 방향으로 이동 방향을 결정한다.
    // 확률에 따라 추첨한다. -> 확률 변수, 랜덤 값

    public int speed;
    // 플레이어를 따라가고싶다.
    public GameObject player;
    public int downrate = 35; //65% 확률로 플레이어를 쫓아감
    Vector3 dir;

    void Start()
    {
        #region Find("Player")
        // 현재 씬에서 "Player" 라는 이름으로 게임 오브젝트를 찾는다.
        // 1. 느림 Find("Player")
        // player = GameObject.Find("Player");
        #endregion

        #region FindObjectsOfType<PlayerMove>();
        // 2 . FindObjectsOfType
        // 현재 씬에서 PlayerMove 컴포넌트를 가지고 있는 오브젝트를 찾는다.
        // 이름으로 찾는 것보다 훨씬 빠르다.
        // PlayerMove playerComp = FindObjectsOfType<PlayerMove>();
        // player = playerComp.gameObject;
        #endregion

        // 태그가 같은 팀이면 데미지 x, 다르면 데미지 o 
        #region GameObject.FindGameObjectWithTag("MyPlayer");
        // 3. 게임 오브젝트에 설정된 태그 이름으로 게임 오브젝트를 찾는다.
        player = GameObject.FindGameObjectWithTag("MyPlayer");
        #endregion
         
        #region GameObject.FindWithTag("MyPlayer");
        //player = GameObject.FindWithTag("MyPlayer");
        #endregion

        // 랜덤한 숫자를 하나 뽑는다. 
        int myNumber =  Random.Range(0, 100);
        // 만일, 뽑은 숫자가 35보다 작으면, 방향을 아래로 설정한다.
        if(myNumber < downrate)
        {
            dir = Vector3.down;
        }
        // 그렇지 않다면, 방향을 플레이어 쪽으로 설정한다.
        else
        {
            // 만일 플레이어가 있다면
            if(player != null)
            {
                // 플레이어를 향한 방향
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }
    }

    void Update()
    {
        // 아래 방향(월드 좌표)
        //Vector3 dir = Vector3.down;

        // 플레이어를 향한 방향으로 계속 바뀐다.
        //Vector3 dir = player.transform.position - transform.position;
        //dir.Normalize();


        // p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 대상이 플레이어라면
        if (other.gameObject.name == "Player")
        {
            // 플레이어를 제거하고
            Destroy(other.gameObject);
        }    
        // 나도 제거한다.
        Destroy(gameObject);
    }  
}
