using UnityEngine;

public class ProfMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // input

        if (input.x != 0 || input.y != 0)
        {
            lastMoveDirection = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        // animasi
        anim.SetFloat("WalkX", input.x);
        anim.SetFloat("WalkY", input.y);

        bool isMoving = input.magnitude > 0;
        anim.SetBool("isMoving", isMoving);
        
        anim.SetFloat("IdleX", lastMoveDirection.x);
        anim.SetFloat("IdleY", lastMoveDirection.y);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}
