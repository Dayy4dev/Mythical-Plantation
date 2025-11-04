using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    AudioSource audioSource;
    Rigidbody2D rb;
    float x;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);

        if (rb.linearVelocity.x != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
