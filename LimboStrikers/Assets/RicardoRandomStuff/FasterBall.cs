using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBall : MonoBehaviour
{

    float DestroyTimer;
    float TimeToDestroy;

    public GameObject VFXFastBall;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        DestroyTimer = Time.time;
        TimeToDestroy = DestroyTimer + 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeToDestroy < Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colliding");
        if (other.gameObject.tag == "ball")
        {
            Instantiate(VFXFastBall, transform.position, Quaternion.identity);

            rb2d = other.GetComponent<Rigidbody2D>();


            rb2d.velocity = rb2d.velocity * 4;

            Destroy(gameObject);
        }
    }
}
