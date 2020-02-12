using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public GameObject playerghost;
    private Rigidbody2D rb;
    private Vector2 move;
    public float speed;
    private bool click;
    public bool dash = false;
    public bool dashready = false;
    public float dashTimer;
    public float startdashTimer;
    public float dashcooldownTimer;
    public float startcooldwondashTimer;
    bool dashrecover;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        click = Input.GetButtonDown("Fire1");
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(move.x, move.y);
        if(!click)
        rb.velocity = movement * speed;
        dashingfunc();
    }

    void dashingfunc()
    {
        Vector2 movement2 = new Vector2(move.x, move.y);
     
            if (click)
            {
                GameObject ghostie = Instantiate(playerghost, transform.position, transform.rotation);
                dashTimer -= Time.deltaTime;
                rb.velocity = movement2 * speed * 2f;
            }
        

    }
}
