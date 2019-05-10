using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ri : MonoBehaviour
{
    private float speed;

    private Rigidbody2D rb;
    public Vector2 jumpHeight;
    public int Health;
    public SpriteRenderer Renderer2;
    private Vector2 knockBack;
    public Animator animator2;
    public GameObject boom;
    private Vector2 playerPos;
    // public GameObject Health2;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpHeight = new Vector2(0, 6);
        knockBack = new Vector2(6, 0);
        speed = 4;
        Health = 100;
    }


    void Update()
    {
    // til þess að koma í veg fyrir að spilarinn gæti "flogið" þá getur hann bara hoppað ef hann er að snerta jörðina
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)  //makes player jump
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            animator2.SetBool("Running", true);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            animator2.SetBool("Attacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            animator2.SetBool("Attacking", false);
        }
    }

    void FixedUpdate()
    {
        playerPos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator2.SetBool("Running", true);
            boom.transform.position = new Vector2(playerPos.x - 0.3f, playerPos.y);
            Renderer2.flipX = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator2.SetBool("Running", true);
            boom.transform.position = new Vector2(playerPos.x + 0.3f, playerPos.y);
            Renderer2.flipX = false;
        }
        else { rb.velocity = new Vector2(0, rb.velocity.y);
            animator2.SetBool("Running", false);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}
