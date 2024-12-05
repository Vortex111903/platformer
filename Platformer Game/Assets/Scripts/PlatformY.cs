using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformY : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float verticalRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > verticalRange)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        if (transform.position.y < -verticalRange)
        {
            rb.velocity = new Vector2(0, +speed);
        }
    }
}
