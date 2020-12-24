using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float mouseSmoothing;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;

    void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseInput = Vector2.Scale(mouseInput, new Vector2(mouseSensitivity * mouseSmoothing, mouseSensitivity * mouseSmoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, mouseInput.x, 1f / mouseSmoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, mouseInput.y, 1f / mouseSmoothing);
        currentLookingPos += smoothedVelocity;

        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, player.transform.up);
        if(-currentLookingPos.y > -90 && -currentLookingPos.y < 90)
            transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
    }
}
