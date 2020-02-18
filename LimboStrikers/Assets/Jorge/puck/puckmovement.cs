using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckmovement : MonoBehaviour
{
    
    public Rigidbody2D rb2D;
    public float thrust = 1.0f;
    public static puckmovement instance;
    private charactermove character;


    Vector3 currentEulerAngles;
    public Quaternion currentRotation;

    Vector3 forward;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        currentEulerAngles = new Vector3(0f, 0f, 0f);
        currentRotation.eulerAngles = currentEulerAngles;

        transform.rotation = currentRotation;
    }

    void FixedUpdate()
    {
        //PuckMovement(character.cross);
        forward = transform.TransformDirection(-Vector3.up) * 10;
        Debug.DrawRay(transform.position, forward, Color.white);
    }

    public void PuckMovement(Vector2 cross)
    {
        //rb2D.AddForce(transform.right * thrust);
        //rb2D.AddForce(Vector3.forward * thrust);
        //rb2D.AddForce(cross.normalized * thrust);
        //rb2D.AddForce(cross * thrust);
        rb2D.velocity = cross * 30;
        //rb2D.velocity *= 2;
        //this.GetComponent<ConstantForce2D>().force = character.transform.TransformDirection(Vector3.forward);
    }
}
