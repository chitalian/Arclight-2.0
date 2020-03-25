using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    public float speed = 10f;
    public const float gravity = 9.81f;
    Vector3 moveDirection;
    public float jumpHeight = 10f;
    public float airControl = 10f;

    private LevelManager levelManager;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (levelManager.IsGameOver()) {
            controller.Move(Vector3.zero);
        } else {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            var input = transform.right * moveHorizontal + transform.forward * moveVertical;
            input *= speed;

            if (controller.isGrounded)
            {
                moveDirection = input;
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = Mathf.Sqrt(2 * gravity * jumpHeight);
                }
            }
            else
            {
                // the object is in the air
                // moveDirection.y = 0f;
                input.y = moveDirection.y;
                moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        
    }
}
