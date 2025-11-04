using UnityEngine;

public class bingBergerak : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    public Rigidbody2D rb;

    private Vector2 input;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true;

    Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // speedX = Input.GetAxis("Horizontal") * moveSpeed;
        // speedY = Input.GetAxis("Vertical") * moveSpeed;
        // rb.linearVelocity = new Vector2(speedX, speedY);

        ProsesInput();
        Animasi();
if (input.x < 0 && !facingLeft || input.x > 0 && facingLeft)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

    void ProsesInput()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    void Animasi()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

}
