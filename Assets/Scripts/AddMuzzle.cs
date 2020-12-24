using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMuzzle : MonoBehaviour
{
    public ParticleSystem MuzzleParticle;

    private void Start()
    {
        ShootEvent.OnShoot += TriggerMuzzle;
    }

    private void TriggerMuzzle()
    {
        MuzzleParticle.Play();
    }
}
