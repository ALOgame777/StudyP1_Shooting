using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // ������ Ȯ���� ���� �Ʒ��� �Ǵ� �÷��̾� �������� �̵� ������ �����Ѵ�.
    // Ȯ���� ���� ��÷�Ѵ�. -> Ȯ�� ����, ���� ��

    public int speed;
    // �÷��̾ ���󰡰�ʹ�.
    public GameObject player;
    public int downrate = 35; //65% Ȯ���� �÷��̾ �Ѿư�
    Vector3 dir;

    void Start()
    {
        #region Find("Player")
        // ���� ������ "Player" ��� �̸����� ���� ������Ʈ�� ã�´�.
        // 1. ���� Find("Player")
        // player = GameObject.Find("Player");
        #endregion

        #region FindObjectsOfType<PlayerMove>();
        // 2 . FindObjectsOfType
        // ���� ������ PlayerMove ������Ʈ�� ������ �ִ� ������Ʈ�� ã�´�.
        // �̸����� ã�� �ͺ��� �ξ� ������.
        // PlayerMove playerComp = FindObjectsOfType<PlayerMove>();
        // player = playerComp.gameObject;
        #endregion

        // �±װ� ���� ���̸� ������ x, �ٸ��� ������ o 
        #region GameObject.FindGameObjectWithTag("MyPlayer");
        // 3. ���� ������Ʈ�� ������ �±� �̸����� ���� ������Ʈ�� ã�´�.
        player = GameObject.FindGameObjectWithTag("MyPlayer");
        #endregion
         
        #region GameObject.FindWithTag("MyPlayer");
        //player = GameObject.FindWithTag("MyPlayer");
        #endregion

        // ������ ���ڸ� �ϳ� �̴´�. 
        int myNumber =  Random.Range(0, 100);
        // ����, ���� ���ڰ� 35���� ������, ������ �Ʒ��� �����Ѵ�.
        if(myNumber < downrate)
        {
            dir = Vector3.down;
        }
        // �׷��� �ʴٸ�, ������ �÷��̾� ������ �����Ѵ�.
        else
        {
            // ���� �÷��̾ �ִٸ�
            if(player != null)
            {
                // �÷��̾ ���� ����
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
        // �Ʒ� ����(���� ��ǥ)
        //Vector3 dir = Vector3.down;

        // �÷��̾ ���� �������� ��� �ٲ��.
        //Vector3 dir = player.transform.position - transform.position;
        //dir.Normalize();


        // p = p0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ����� �÷��̾���
        if (other.gameObject.name == "Player")
        {
            // �÷��̾ �����ϰ�
            Destroy(other.gameObject);
        }    
        // ���� �����Ѵ�.
        Destroy(gameObject);
    }  
}
