using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    public bool isGrounded;
    public GameManager gm;
    public bool hasJumped;
    public int jumpNumber;

    public AudioSource soundEffect;
    public AudioClip collect;
    // animation variables
    Animator anim;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) 
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            moving = true;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = +currentScale;
            moving = true;
        }
        if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpNumber=1;
        }
        if (jumpNumber == 1 && Input.GetKeyDown("w") && hasJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpNumber = 0;
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            moving = false;
        }
        anim.SetBool("isMoving", moving);

        transform.position = newPosition;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
            hasJumped = false;
        }
        if (collision.gameObject.tag.Equals("Platform"))
        {
            isGrounded = true;
            hasJumped = false;
        }
        if (collision.gameObject.tag.Equals("Coin"))
        {
            gm.score++;
            Destroy(collision.gameObject);
            soundEffect.PlayOneShot(collect, .5f);
        }
        if (collision.gameObject.tag.Equals("Coin 2"))
        {
            gm.score += 2;
            Destroy(collision.gameObject);
            soundEffect.PlayOneShot(collect, .5f);
        }
        if (collision.gameObject.tag.Equals("Spike"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
        } 
        if(collision.gameObject.tag.Equals("Spike 2"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.tag.Equals("Door"))
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
            hasJumped = true;
            
        }
        if (collision.gameObject.tag.Equals("Platform"))
        {
            isGrounded = false;
            hasJumped = true;
        }

    }
}
