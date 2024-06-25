using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 계속 이동하고 싶다.
        //방향: 위로, 이동속력 : float, public
        //이동 공식 : p = p0+vt , p += vt
        
        // 월드 방향
        Vector3 worldDir = Vector3.up;

        // 로컬 방향(나를 기준)
        Vector3 localDir = transform.up;

        transform.position += localDir * speed * Time.deltaTime;
        //transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }
}
