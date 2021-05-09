using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterEffect : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
