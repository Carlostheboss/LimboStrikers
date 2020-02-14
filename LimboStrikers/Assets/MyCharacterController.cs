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
    public float currentAmount;
    public float speedcooldown;

    float speedtimer = 5.0f;

    public float pusherCooldown;
    private float nextPush = 0;
    public GameObject pusher;
    private GameObject InstantiatedPusher;

    // Start is called before the first frame update

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
        rb.velocity = movement * speed;
        dashingfunc();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && Time.time > nextPush)
        {
            nextPush = Time.time + pusherCooldown;

            Instantiate(pusher, transform.position, transform.rotation, this.gameObject.transform);


        }


        if (currentAmount <= 100)
        {
            currentAmount += speedcooldown * Time.deltaTime;
        }
        else
        {
            currentAmount = 100;
            speedcooldown = 0;
        }


		if (speed != 10)
		{
			speedtimer -= Time.deltaTime;

			if (speedtimer < 0)
			{

				speed = 10.0f;

				speedtimer = 5.0f;
			}


		}
	}

    void dashingfunc()
    {
        Vector2 movement2 = new Vector2(move.x, move.y);

        if (dashTimer <= 0)
        {
            dash = false;
            rb.velocity = Vector2.zero;
            dashTimer = startdashTimer;
        }

        if (dashready == false)
        {
            if ((click && dash == false) || (Input.GetKeyDown(KeyCode.J) && dash == false))
            {
                dash = true;
                dashready = true;
            }
        }

        if (dash == true && dashTimer > 0)
        {
            //dashaudiodata.Play(0);
            GameObject ghostie = Instantiate(playerghost, transform.position, transform.rotation);
            dashTimer -= Time.deltaTime;
            rb.velocity = movement2 * speed * 3f;
        }

        if (currentAmount == 100)
        {
            speedcooldown = 0;
        }
        else if (currentAmount <= 0)
        {
            speedcooldown = 180;
            dashrecover = true;
        }

        if (dashcooldownTimer <= 0)
        {
            dashready = false;
            dashcooldownTimer = startcooldwondashTimer;

        }
        else if (dashready == true && dashcooldownTimer > 0)
        {
            if (currentAmount > 99 && !dashrecover)
                speedcooldown = -200;

            dashcooldownTimer -= Time.deltaTime;
        }

        if (!dashready)
        {
            dashrecover = false;
        }

    }
}
