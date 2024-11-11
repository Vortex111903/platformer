using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpSpeed;
    private SpriteRenderer sr;

    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite frontSprite;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("a")) 
        {
            newPosition.x -= speed;
        }
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
        }
        if (Input.GetKey("w"))
        {
            newPosition.y += JumpSpeed;
        }
        transform.position = newPosition;
    }
}
