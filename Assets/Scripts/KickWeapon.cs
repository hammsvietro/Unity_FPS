using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickWeapon : MonoBehaviour
{
    public GameObject Gun;

    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = Gun.GetComponent<Animator>();
        ShootEvent.OnShoot += Shoot;
    }

    private void Update()
    {

    }

    public void Shoot()
    {
        animator.Play("Shoot");
    }
}
