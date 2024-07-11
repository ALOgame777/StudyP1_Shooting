using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float appearSpeed = 3f;
    public Transform startPos;
    Vector3 starting;
    float late;
    

    void Start()
    {
        starting = transform.position;
    }

    void Update()
    {
        // 1. Lerp를 이용한 방법
        //transform.position =  Vector3.Lerp(transform.position, startPos.position, Time.deltaTime);
        //late += Time.deltaTime;
        //transform.position = Vector3.Lerp(starting, startPos.position, late * 0.3f);

        // 2. p = p0 +vt 방식을 이용한 방법
        //if (transform.position.y < startPos.position.y)
        //{
        //    transform.position = startPos.position;
        //}
        //else
        //{
        //    Vector3 dir = startPos.position - transform.position;
        //    dir.Normalize();
        //    transform.position += dir * appearSpeed * Time.deltaTime;
        //}

        // 거리를 구할 때는
        Vector3 dir = startPos.position - transform.position;
        if (dir.magnitude < 0.1f)
        {
            transform.position = startPos.position;
        }
        else
        {
            dir.Normalize();
            transform.position += dir * appearSpeed * Time.deltaTime;
        }
    }

   
}
