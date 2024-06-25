using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tails : MonoBehaviour
{
    public GameObject targetTail;
    public int speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 타겟을 쫓아가고 싶다.
        // 타겟(GameObject)을 설정한다.
        // 타겟을 향한 방향을 계산한다.
        // 계산된 방향과 지정된 속력으로 이동한다.
        Vector3 dir = targetTail.transform.position - transform.position;
        #region 강사님 추가된 코드
        // 강사님 추가된 코드
        dir.Normalize();
        #endregion

        transform.position += dir * speed * Time.deltaTime;
    }
}
