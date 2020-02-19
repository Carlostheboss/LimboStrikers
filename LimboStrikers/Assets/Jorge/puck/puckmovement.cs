using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckmovement : MonoBehaviour
{
    
    public Rigidbody2D rb2D;
    public float thrust = 1.0f;
    public static puckmovement instance;


    Vector3 currentEulerAngles;
    public Quaternion currentRotation;


    public Vector3 PrevLoc;
    public Vector3 DifLoc;


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
        transform.position = new Vector3(0.0f, 0.0f, 10.0f);

        currentEulerAngles = new Vector3(0f, 0f, 0f);
        currentRotation.eulerAngles = currentEulerAngles;

        transform.rotation = currentRotation;
    }

    void FixedUpdate()
    {
        DifLoc = transform.position - PrevLoc;
        PrevLoc = transform.position;
    }

    public void PuckMovement(Vector2 cross)
    {
        rb2D.velocity = cross * 45;
    }
}
