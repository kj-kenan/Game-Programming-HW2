using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float runMultiplier = 1.8f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Vector3 inputDirection;
    private float currentSpeed;
    private bool isJumping = false;
    private bool isGrounded = false;
    public bool haveKey = false;


    public Transform cameraTransform;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 move = (camForward * vertical + camRight * horizontal).normalized;

        currentSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = walkSpeed * runMultiplier;

        inputDirection = move;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            isJumping = true;
    }

    private void FixedUpdate()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.1f;
        isGrounded = Physics.Raycast(rayStart, Vector3.down, 0.2f);

        if (inputDirection.sqrMagnitude > 0f)
        {
            Vector3 moveVelocity = inputDirection * currentSpeed;

            Vector3 velocity = rb.velocity;
            velocity.x = moveVelocity.x;
            velocity.z = moveVelocity.z;
            rb.velocity = velocity;

            transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
        }
        else
        {
            Vector3 velocity = rb.velocity;
            velocity.x = 0f;
            velocity.z = 0f;
            rb.velocity = velocity;
        }

        if (isJumping)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;

            isJumping = false;
        }

        float horizontalSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        anim.SetFloat("MoveSpeed", horizontalSpeed);
        anim.SetBool("Grounded", isGrounded);
    }
}