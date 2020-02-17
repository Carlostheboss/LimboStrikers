using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    public float speed = 10.0f;
    public puckmovement Puck;
    public bool press = false;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private float newYscale = 0.0f;
    public static charactermove instance;

    private Vector3 heading;
    private float distance;
    public Vector3 direction;

    public Vector3 side;
    public Vector3 cross;


    public Vector3 currentEulerAngles;
    public Quaternion currentRotation;


    public bool timer = false;

    public GameObject nariz;
    private CircleCollider2D cc2d;

    Vector2 perpendicular;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Puck = puckmovement.instance;
        newYscale = transform.localScale.y * -1f;
        cc2d = GetComponent<CircleCollider2D>();
    }

    
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }

    void Update()
    {
        if (press)
        {
            Debug.Log("JumpDown");
            transform.RotateAround(this.transform.position, zAxis, 2);
            Puck.thrust = 0.0f;
            cross = new Vector3(0, 0, 0);
            Puck.transform.parent = this.transform;
            Puck.rb2D.simulated = false;
            //Puck.transform.rotation = this.transform.rotation;
            //transform.LookAt(Puck.transform);
            //cc2d.radius = 0.55f;
            //Puck.transform.position = new Vector3(nariz.transform.position.x, nariz.transform.position.y, 0); 
            //Puck.transform.rotation = nariz.transform.rotation;

            heading = Puck.transform.position - transform.position;
            Debug.Log("heading" + heading);
            heading.Normalize();
            //side = Vector3.Cross(heading, Puck.transform.right);
            //cross = Vector3.Cross(heading, side);
            //cross = heading + Puck.transform.right;
            perpendicular = Vector2.Perpendicular(heading);
            Debug.Log("perpendicular" + perpendicular);
            Debug.Log("cross" + cross);

            Puck.PuckMovement(perpendicular);


            timer = false;


            if (Puck.transform.parent == this.transform)
            {
                Debug.Log("object is attached");
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            press = false;
            timer = true;

        }
        if (!press)
        {
            Debug.Log("JumpUp");
            transform.RotateAround(this.transform.position, zAxis, 0);
            cc2d.radius = 0.5f;
            //currentEulerAngles = new Vector3(0f, 0f, 0f);
            //currentRotation.eulerAngles = currentEulerAngles;
            //transform.rotation = currentRotation;


            Puck.thrust = 2.0f;
            Puck.transform.parent = null;
            Puck.rb2D.simulated = true;
            //Puck.transform.rotation = Puck.currentRotation;

            //Puck.PuckMovement(cross);
            //Puck.PuckMovement(perpendicular);
            Debug.Log("cross 2" + cross);

            if (Puck.transform.parent != this.transform)
            {
                Debug.Log("object is not attached");
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puck")
        {
            if (Input.GetButtonDown("Jump"))
            {
                press = true;
            }
        }
    }
}
