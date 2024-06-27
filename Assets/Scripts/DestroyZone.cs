using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 부딪힌 대상을 모두 파괴한다. 단, 플레이어는 제외한다.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
