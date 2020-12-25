using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootEvent : MonoBehaviour
{
    public delegate void ShootAction();
    
    public static event ShootAction OnShoot;

    public float MaxShotsPerSecond;
    private bool canFire = true;

    private void Update()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;

            OnShoot?.Invoke();

            yield return new WaitForSeconds(1/MaxShotsPerSecond);

            canFire = true;
        }
    }
}
