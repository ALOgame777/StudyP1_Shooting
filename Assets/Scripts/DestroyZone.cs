using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // �ε��� ����� ��� �ı��Ѵ�. ��, �÷��̾�� �����Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
