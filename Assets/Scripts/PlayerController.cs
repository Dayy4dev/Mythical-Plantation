using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true;

    public bool autoMove = false;
    public float moveDuration = 2f;
    public float idleDuration = 1.5f;

    private float timer;
    private bool isMoving = true;
    private Vector2 randomDirection;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = Random.Range(0, moveDuration);
        randomDirection = GetRandomDirection();
    }

    void Update()
    {
        if (autoMove)
        {
            AutoMovement();
        }
        else
        {
            ProsesInput();
        }

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

        input.x = moveX;
        input.y = moveY;
        input.Normalize();
    }

    void AutoMovement()
    {
        timer -= Time.deltaTime;

        if (isMoving)
        {
            input = randomDirection;

            if (timer <= 0)
            {
                isMoving = false;
                timer = idleDuration;
                input = Vector2.zero;
            }
        }
        else
        {
            input = Vector2.zero;

            if (timer <= 0)
            {
                isMoving = true;
                timer = moveDuration;
                randomDirection = GetRandomDirection();
            }
        }
    }

    Vector2 GetRandomDirection()
    {
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        dir.Normalize();
        return dir;
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
