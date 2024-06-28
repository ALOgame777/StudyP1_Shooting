using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLifespan : MonoBehaviour
{
    public float lifespan = 1.5f;
    float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > lifespan)
        {
            Destroy(gameObject);
        }
    }   
}
