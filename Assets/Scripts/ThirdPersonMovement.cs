using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller;
    public float speed = 6f;
    public float runSpeed = 10f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public ParticleSystem jetpackParticles;
    public PlayerController player;
    float turnSmoothVelocity;
    float velocityY = 0;
    private Animator animator;
    
    private void Start() {
        animator = GetComponent<Animator>();
    }
    

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude *= 2f;
        }

        if (controller.isGrounded) {
            // velocityY = 0f;
            animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        } else {
            animator.SetFloat("Input Magnitude", 0f, 0.05f, Time.deltaTime);
        }
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            // If the player is holding shift, use runSpeed
            if (Input.GetKey(KeyCode.LeftShift)) {
                controller.Move(moveDir * runSpeed * Time.deltaTime);
            } else {
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        }

        if (player.JetpackFuel > 0 && Input.GetKey(KeyCode.E)) {
            velocityY = 2f;
            player.UseJetpack(0.5f);
            jetpackParticles.Play();
        } else {
            jetpackParticles.Stop();
        }

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        } 

        if (controller.isGrounded && velocityY < 0) {
            velocityY = -2f;
        }


        
        velocityY += gravity * Time.deltaTime;
        controller.Move(Vector3.up * velocityY * Time.deltaTime);
    }


}
