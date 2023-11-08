using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleWhenDone : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    void Update()
    {
        if(ps.isPlaying == false) Destroy(gameObject);
    }
}
