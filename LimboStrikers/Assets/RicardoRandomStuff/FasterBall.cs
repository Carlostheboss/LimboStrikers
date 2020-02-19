using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBall : MonoBehaviour
{

    float DestroyTimer;
    float TimeToDestroy;

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
            Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
            puckmovement ballscript = other.gameObject.GetComponent<puckmovement>();

            rb2d.AddForce(  ballscript.DifLoc * 100.0f, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }
}
