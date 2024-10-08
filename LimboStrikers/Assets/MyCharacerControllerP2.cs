﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacerControllerP2 : MonoBehaviour
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

    public float speedtimer = 3.0f;
    public int changeballdirPU = 0;
    public GameObject ChangeBall;

    public float pusherCooldown;
    private float nextPush = 0;
    public GameObject pusher;
    private GameObject InstantiatedPusher;



    public puckmovement Puck;
    public bool press = false;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public static MyCharacerControllerP2 instance;
    private Vector3 heading;
    public bool timer = false;
    Vector2 perpendicular;
    public Vector3 currentEulerAngles;
    public Quaternion currentRotation;

    private MyCharacterController myCharacterController;

    public bool touch = false;
    public AudioSource ThrowingSound;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

        Puck = puckmovement.instance;

        myCharacterController = MyCharacterController.instance;
    }


    void FixedUpdate()
    {
        click = Input.GetButtonDown("Fire2");
        move.x = Input.GetAxis("Horizontal2");
        move.y = Input.GetAxis("Vertical2");
        Vector2 movement = new Vector2(move.x, move.y);
        rb.velocity = movement * speed;
        dashingfunc();
    }

    private void Update()
    {
        if (touch == true)
        {
            if (press)
            {
              
                myCharacterController.touch = false;
                //Debug.Log("JumpDown");
                transform.RotateAround(this.transform.position, zAxis, 15);
                Puck.thrust = 0.0f;
                Puck.transform.parent = this.transform;
                Puck.rb2D.simulated = false;

                heading = Puck.transform.position - transform.position;
                //Debug.Log("heading" + heading);
                heading.Normalize();
                perpendicular = Vector2.Perpendicular(heading);
                //Debug.Log("perpendicular" + perpendicular);

                Puck.PuckMovement(perpendicular);

                timer = false;


                if (Puck.transform.parent == this.transform)
                {
                    Debug.Log("object is attached");
                }
            }
            if (Input.GetButtonUp("Rotate"))
            {
                ThrowingSound.pitch = 1.47f;
                ThrowingSound.PlayOneShot(ThrowingSound.clip, ThrowingSound.volume);
                press = false;
                timer = true;
                touch = false;
                //Debug.Log("ROTATE 3");
            }
            if (!press && myCharacterController.press)
            {
                //Debug.Log("JumpUp");
                transform.RotateAround(this.transform.position, zAxis, 0);

                Puck.thrust = 2.0f;
                Puck.transform.parent = myCharacterController.transform;
                Puck.rb2D.simulated = true;

                if (Puck.transform.parent != this.transform)
                {
                    Debug.Log("object is not attached");
                }
            }
            else if (!press && !myCharacterController.press)
            {
                //Debug.Log("JumpUp");
                transform.RotateAround(this.transform.position, zAxis, 0);

                Puck.thrust = 2.0f;
                Puck.transform.parent = null;
                Puck.rb2D.simulated = true;

                if (Puck.transform.parent != this.transform)
                {
                    Debug.Log("object is not attached");
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Keypad6) && Time.time > nextPush)
        {
            nextPush = Time.time + pusherCooldown;

            Instantiate(pusher, transform.position, transform.rotation, this.gameObject.transform);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4) && changeballdirPU > 0)
        {
            Debug.Log(changeballdirPU);
            GameObject PUChangeBall = Instantiate(ChangeBall, transform.position, Quaternion.identity);
            ChangeBallDir ChangeBallScript = PUChangeBall.GetComponent<ChangeBallDir>();
            ChangeBallScript.placed = true;

            changeballdirPU -= 1;
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
                speed = 15.0f;
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
            if ((click && dash == false) || (Input.GetKeyDown(KeyCode.Keypad5) && dash == false))
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
