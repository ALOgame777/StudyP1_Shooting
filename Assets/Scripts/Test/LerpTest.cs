using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public float percent = 0;
    public Transform startPos;
    public Transform endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percent += Time.deltaTime * 0.5f;
        Vector3 result =  Vector3.Lerp(startPos.position, endPos.position, percent);
        transform.position = result;
    }
}
