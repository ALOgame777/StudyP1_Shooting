using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // �ε��� ����� ��� �ı��Ѵ�. ��, �÷��̾�� �����Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
