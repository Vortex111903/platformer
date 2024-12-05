using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float horizontalRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x> horizontalRange)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (transform.position.x < -horizontalRange)
        {
            rb.velocity = new Vector2(+speed, 0);
        }
    }
}
