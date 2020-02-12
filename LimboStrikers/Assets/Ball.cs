using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Collider2D wallCollider;
    public Collider2D ballCollider;

    public Rigidbody2D rb;
    //public float wallBounceForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        wallCollider = GameObject.FindGameObjectWithTag("wall").GetComponent<Collider2D>();
        ballCollider = this.gameObject.GetComponent<Collider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        rb.AddForceAtPosition(this.transform.up * 200, this.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        

        /*if (ballCollider.IsTouching(wallCollider))
        {
            Debug.Log("touch");
           // rb.AddForceAtPosition(this.transform.up * 200, wallCollider.transform.position);
        }*/


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }




}
