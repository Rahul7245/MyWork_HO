using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        dust = gameObject.GetComponentInChildren<ParticleSystem>();
        dust.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void PlayParticle() {
        dust.Play();
    }

    public void StopParticle() {
        dust.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
