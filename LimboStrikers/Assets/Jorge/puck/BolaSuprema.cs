using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaSuprema : MonoBehaviour
{
    public static BolaSuprema instance;
    private MyCharacterController character;
    public Rigidbody2D rb2D;
    public float thrust = 2.0f;

    Vector3 currentEulerAngles;
    public Quaternion currentRotation;



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

        currentEulerAngles = new Vector3(0f, 0f, 0f);
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }


    public void PuckMovement(Vector2 cross)
    {
        rb2D.velocity = cross * thrust;
    }
}
