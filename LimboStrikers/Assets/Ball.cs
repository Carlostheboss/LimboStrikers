using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Collider2D wallCollider;
    public Collider2D ballCollider;
    public Rigidbody2D rb;
    public Transform player;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    public Vector3 PrevLoc;
    public Vector3 DifLoc;

    public float thrust = 10.0f;

    public static Ball instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        //wallCollider = GameObject.FindGameObjectWithTag("wall").GetComponent<Collider2D>();
        ballCollider = this.gameObject.GetComponent<Collider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

      
    }


    void Update()
    {
        DifLoc = transform.position - PrevLoc;
        PrevLoc = transform.position;
    }


    private void FixedUpdate()
    {
        //transform.RotateAround(player.position, zAxis, 2);
    }


    public void PuckMovement(Vector2 cross)
    {
        rb.velocity = cross * thrust;
    }
}


