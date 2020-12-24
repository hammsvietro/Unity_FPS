using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootEvent : MonoBehaviour
{
    public delegate void ShootAction();
    
    public static event ShootAction OnShoot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }
}
