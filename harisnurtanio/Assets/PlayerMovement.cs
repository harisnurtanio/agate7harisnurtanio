using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerak pemain
    public float gravity = 9.81f; // Gravitasi
    public float jumpHeight = 2f; // Ketinggian lompatan
    private CharacterController controller;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection;
        }

        if (controller.isGrounded)
        {
            velocity.y = -2f; // Reset gravitasi saat di tanah

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity); // Perhitungan lompatan
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        controller.Move((moveDirection * moveSpeed + velocity) * Time.deltaTime);
    }
}
