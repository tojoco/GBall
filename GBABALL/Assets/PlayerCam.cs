using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Start is called before the first frame update
    public float Sensx;
   public float Sensy;

   public Transform orientation;

   float xRotation;
   float yRotation;
private void Start() 
{
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

}

private void Update() 
{
    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensx;
    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensy;

    yRotation += mouseX;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    orientation.rotation = Quaternion.Euler(0, yRotation, 0);
}
}
