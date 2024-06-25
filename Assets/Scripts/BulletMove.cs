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
        // ���� ��� �̵��ϰ� �ʹ�.
        //����: ����, �̵��ӷ� : float, public
        //�̵� ���� : p = p0+vt , p += vt
        
        // ���� ����
        Vector3 worldDir = Vector3.up;

        // ���� ����(���� ����)
        Vector3 localDir = transform.up;

        transform.position += localDir * speed * Time.deltaTime;
        //transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }
}
