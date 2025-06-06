using Unity.VisualScripting;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    // This Script Deals with the Player movement Rather Than Managing the Player Movement .

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private bool lerpCrouch;
    public float crouchTimer = 0f;
    private bool crouching;
    private bool sprinting;


    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }

            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }

    // Recieves the inputs from the InputManger.cs and apply to our CharacterController
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y; // We are Actually translating the Vector2 vertical motion on Z Axis for Forward and Backward Motion;
        controller.Move(transform.TransformDirection(moveDirection) *  speed * Time.deltaTime);
        playerVelocity.y = playerVelocity.y + gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y); 
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        } 
    }
}
