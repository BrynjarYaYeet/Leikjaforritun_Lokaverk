using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    private float speed2;

    private Rigidbody2D rb2;
    public Vector2 jumpHeight;
    public Animator animator;
    public SpriteRenderer Renderer;
    private int DMG = 10;
    public int Health = 100;
    public GameObject sword;
    private Vector2 playerPos;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        jumpHeight = new Vector2(0, 6);
        speed2= 4;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //makes player jump
        {
            if (isGrounded){
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) 
        {
            animator.SetBool("Attacking", true);
        } else if (Input.GetKeyUp(KeyCode.G)) 
        {
            animator.SetBool("Attacking", false);
        } 
    }

    void FixedUpdate()
    {
        playerPos = transform.position;


        if (Input.GetKey(KeyCode.A))
        {
            
            rb2.velocity = new Vector2(-speed2, rb2.velocity.y);
            animator.SetBool("Running", true);
            sword.transform.position = new Vector2(playerPos.x - 0.7f ,playerPos.y);
            Renderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb2.velocity = new Vector2(speed2, rb2.velocity.y);
            animator.SetBool("Running", true);
            sword.transform.position = new Vector2(playerPos.x + 0.7f, playerPos.y);
            Renderer.flipX = false;
        }
        else { 
            rb2.velocity = new Vector2(0, rb2.velocity.y);
            animator.SetBool("Running", false);
        }

        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jumping", false);
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
