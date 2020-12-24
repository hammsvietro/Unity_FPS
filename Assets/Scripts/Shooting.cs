using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Gun;
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = Gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Shoot");
        }
    }
}
