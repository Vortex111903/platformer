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
        if (Input.GetKey("w") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        }
        if (collision.gameObject.tag.Equals("Coin"))
        {
            gm.score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Spike"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(1);
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }
}
