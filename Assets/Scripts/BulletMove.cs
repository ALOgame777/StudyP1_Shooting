using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float lifeSpan = 3.0f;
    public GameObject explosionPrefab;

    PlayerFire pFire;

    void Start()
    {
        //player ������Ʈ�� PlayerFire ������Ʈ�� ������ �����Ѵ�.
        if (player != null)
        {
            pFire = player.GetComponent<PlayerFire>();
        }
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

        // ������ span�� 3�ʰ� �Ǹ� ����
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            if (pFire.useObjectPool || pFire.useArray)
            {
                Reload();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }



    // ������ �浹�� �߻����� �� ����Ǵ� �̺�Ʈ �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ���� ������Ʈ�� �����Ѵ�.
        Destroy(collision.gameObject);

        // ���� �����Ѵ�.
        Destroy(gameObject);
    }

    // ������ �浹 ���� �浹 ������ ���� �� ����Ǵ� �̺�Ʈ �Լ�
    private void OnTriggerEnter(Collider col)
    {
        // �浹�� ���� ������Ʈ�� �����Ѵ�.
        EnemyMove enemy = col.gameObject.GetComponent<EnemyMove>();

        // enemy ������ ���� �ִٸ�..
        if (enemy != null)
        {
            // �浹�� ���ʹ� ������Ʈ�� �����Ѵ�.
            Destroy(col.gameObject);

            // GameManager�� �ִ� currentScore ���� 1 �߰��Ѵ�.
            GameManager.gm.AddScore(10);

            // ���� ����Ʈ �����ո� ���ʹ̰� �ִ� �ڸ��� �����Ѵ�.
            GameObject explosion = Instantiate(explosionPrefab, col.transform.position, col.transform.rotation);
            //GameObject fx = Instantiate(explosionPrefab, col.transform.position, col.transform.rotation);

            // ������ ���� ����Ʈ ������Ʈ���� ��ƼŬ �ý��� ������Ʈ�� �����ͼ� �÷����Ѵ�.

            //ParticleS
            //ystem ps = fx.GetComponent<ParticleSystem>();
            ParticleSystem fx = explosion.GetComponent<ParticleSystem>();
            fx.Play();
            // ps.Play();
            // �÷��̾� ���� ������Ʈ�� �پ��ִ� PlayerFire ������Ʈ�� �����´�.
            if(player != null)
            { 
                PlayerFire playerFire = player.GetComponent<PlayerFire>();
                playerFire.PlayExplosionSound();
            }

            // PlayerFire ������Ʈ�� �ִ� PlayExplosionSound �Լ��� �����Ѵ�.
        }

        // ���� �����Ѵ�.
        //Destroy(gameObject); 
        if (pFire.useObjectPool || pFire.useArray)
        {
            Reload();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Reload()
    {
        if (pFire.useObjectPool)
        {
            // �ڱ� �ڽ��� bullets ����Ʈ�� �߰��ϰ�, ��Ȱ��ȭ�Ѵ�.
            pFire.bullets.Add(gameObject);
            lifeSpan = 3.0f;
            gameObject.SetActive(false);
            if(player != null)
            {
                gameObject.transform.parent = player.transform;
            }

        }
        else if (pFire.useArray)
        {
            // bulletArray �迭�� �� ���� �ִ� ���� ã�´�.
            for (int i = 0; i < pFire.bulletArray.Length; i++)
            {
                //���� i ��° �ε����� ���� null�̶��...
                if(pFire.bulletArray[i] == null)
                {
                    pFire.bulletArray[i] = gameObject;
                    gameObject.SetActive(false);
                    lifeSpan = 3.0f;
                    if(player != null)
                    {
                        gameObject.transform.parent = player.transform;
                    }
                    break;
                }

            }



        }

    }
}