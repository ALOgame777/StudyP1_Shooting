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
        // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {    
            // 2. �Ѿ��� �����Ѵ�.
             GameObject go = Instantiate(bulletPrefab);

            // 3. ������ �Ѿ��� �ѱ��� �ű��.
            // 3-1. �ѱ��� ���� ������Ʈ ������ ���� �����ϴ� ���
            go.transform.position = firePosition.transform.position;
            // 3-2. �ѱ��� �÷��̾��� ��ġ���� ���� 1.5���� ������ �����ϴ� ���
            //Vector3 firePos = go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            //go.transform.position = firePos;
            // == go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
