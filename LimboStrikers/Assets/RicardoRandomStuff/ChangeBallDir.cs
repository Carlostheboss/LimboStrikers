using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallDir : MonoBehaviour
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

        if (other.gameObject.tag == "ball")
        {
            Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
            float randVal = Random.Range(-1, 1.1f);

            Vector3 ballT = new Vector3(0, randVal, 0);



            rb2d.AddForce(ballT * 20.0f, ForceMode2D.Impulse);


            Destroy(gameObject);
        }
    }
}
