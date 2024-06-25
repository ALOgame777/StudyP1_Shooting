using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // �Ʒ� �������� ��� �̵��ϰ� �ʹ�.
    public int speed;

    // �÷��̾ ���󰡰�ʹ�.
    public GameObject player;
    Vector3 dir;

    void Start()
    {
        // ���� ����� �ѹ��� ����
        #region �±׷� ã�� ���
        // �±׷� ã�� ��� 1
        //player = GameObject.FindWithTag("Player");
        #endregion
        player = GameObject.FindGameObjectWithTag("Player");
        dir = player.transform.position - transform.position;
        dir.Normalize();
    }

    void Update()
    {
        // �Ʒ� ����(���� ��ǥ)
        //Vector3 dir = Vector3.down;

        // �÷��̾ ���� �������� ��� �ٲ��.
        //Vector3 dir = player.transform.position - transform.position;
        //dir.Normalize();


        // p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
