using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShootSound : MonoBehaviour
{

    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        ShootEvent.OnShoot += PlaySound;
    }

    private void OnDisable()
    {
        ShootEvent.OnShoot -= PlaySound;
    }

    void PlaySound()
    {
        audio.Play();
    }
}
