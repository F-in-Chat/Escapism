using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool inInterface = false;
    
    private GroundCheck groundCheck;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 GroundCheckPosition => groundCheck ? groundCheck.transform.position : Vector3.zero;

    void Awake()
    {
        controller = Character.GetComponent<CharacterController>(this);
        groundCheck = Character.GetComponent<GroundCheck>(this);
        HexagonPuzzleManager.onHasEnteredInterface += InInterface;
        OptionsMenu.onOpenOptionMenu += InInterface;
        FirstLevelManager.onFadingInLevel += InInterface;
    }

    void Update()
    {
        if (!controller) return;
        if (inInterface) return;

        isGrounded = Physics.CheckSphere(GroundCheckPosition, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void InInterface(bool hasEntered)
    {
        inInterface = hasEntered;
    }
}