using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // 아래 방향으로 계속 이동하고 싶다.
    public int speed;

    // 플레이어를 따라가고싶다.
    public GameObject player;
    Vector3 dir;

    void Start()
    {
        // 방향 계산을 한번만 실행
        player = GameObject.FindWithTag("Player");
        dir = player.transform.position - transform.position;
        dir.Normalize();
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
}
