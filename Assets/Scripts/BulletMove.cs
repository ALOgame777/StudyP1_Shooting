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

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 계속 이동하고 싶다.
        //방향: 위로, 이동속력 : float, public
        //이동 공식 : p = p0+vt , p += vt
        
        // 월드 방향
        //Vector3 worldDir = Vector3.up;

        // 로컬 방향(나를 기준)
        Vector3 localDir = transform.up;

        transform.position += localDir * speed * Time.deltaTime;
        //transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        
        // 라이프 span이 3초가 되면 삭제
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    

    // 물리적 충돌이 발생했을 때 실행되는 이벤트 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 게임 오브젝트를 제거한다.
        Destroy(collision.gameObject);
        
        // 나를 제거한다.
        Destroy(gameObject);

    }

    // 물리적 충돌 없이 충돌 감지만 했을 때 실행되는 이벤트 함수
    private void OnTriggerEnter(Collider col)
    {
        // 충돌한 게임 오브젝트를 제거한다.
        EnemyMove enemy =  col.gameObject.GetComponent<EnemyMove>();
        
        // enemy 변수에 값이 있다면..
        if(enemy != null)
        {
            Destroy(col.gameObject);

            // 폭발 이펙트 프리팹를 에너미가 있던 자리에 생성한다.
            GameObject explosion = Instantiate(explosionPrefab, col.transform.position, col.transform.rotation);
            //GameObject fx = Instantiate(explosionPrefab, col.transform.position, col.transform.rotation);
            
            // 생성한 폭발 이펙트 오브젝트에서 파티클 시스템 컴포넌트를 가져와서 플레이한다.
            
            //ParticleSystem ps = fx.GetComponent<ParticleSystem>();
            ParticleSystem fx = explosion.GetComponent<ParticleSystem>();
            fx.Play();
            // ps.Play();
            // 플레이어 게임 오브젝트에 붙어있는 PlayerFire 컴포넌트를 가져온다.
            PlayerFire playerFire = player.GetComponent<PlayerFire>();

            // PlayerFire 컴포넌트에 있는 PlayExplosionSound 함수를 실행한다.
            playerFire.PlayExplosionSound();
        }

        // 나를 제거한다.
        Destroy(gameObject);
        
    }


}
