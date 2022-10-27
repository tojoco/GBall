using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject CameraHolder;
    public float sensitivity, maxForce, jumpForce, speed, SprintSpeed ;
    private Vector2 move, look;
    private float lookRotation;
    public bool grounded, sprinting, isCrouching;

     [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
 
    public void OnMove (InputAction.CallbackContext context) 
    {
        move = context.ReadValue<Vector2>();
    }
 
    public void Onlook (InputAction.CallbackContext context) 
    {
        look = context.ReadValue<Vector2>();
    }
 
     public void OnJump (InputAction.CallbackContext context) 
    {
        Jump();
    }
 
      public void Sprint (InputAction.CallbackContext context){
         sprinting = context.ReadValueAsButton();
        
         }

      public void OnCrouch(InputAction.CallbackContext context) 
      {
        isCrouching = context.ReadValueAsButton();
        crouch();
      }


   
 
    private void FixedUpdate() 
    {
      Move();
    }
 
    void Jump() 
    {
        Vector3 jumpForces = Vector3.zero;
        if(grounded) 
        {
            jumpForces = Vector3.up * jumpForce;
        }
        rb.AddForce(jumpForces,ForceMode.Impulse);
    }
    void Move() 
    {
          //find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move. y);
        if (sprinting && !isCrouching)
        {
        targetVelocity *= SprintSpeed;
        } else if (isCrouching) {
        targetVelocity *= crouchSpeed;
        } else 
        {
            targetVelocity *= speed;
        }
        //allign dibrection
        targetVelocity = transform.TransformDirection(targetVelocity);
 
        //calc force
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
 
        //limit force
        //Vector3.ClampMagnitude(velocityChange, maxForce);
 
        rb.AddForce(velocityChange, ForceMode.Impulse);
    }
    void Look()
    {
        //turn
        transform.Rotate(Vector3.up * look.x * sensitivity);
 
        //look
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        CameraHolder.transform.eulerAngles = new Vector3(lookRotation, CameraHolder.transform.eulerAngles.y, CameraHolder.transform.eulerAngles.z);
 
    }
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        startYScale = transform.localScale.y;
    }
 
    // Update is called once per frame
    void Update()
    {
 
    }
 
    void LateUpdate() 
    {
       Look(); 
    }
 
    public void SetGrounded(bool state) 
    {
        grounded = state;
    }
 
    public void crouch() 
    {
        if(isCrouching && grounded) 
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        } else 
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
 
    
 
 
}