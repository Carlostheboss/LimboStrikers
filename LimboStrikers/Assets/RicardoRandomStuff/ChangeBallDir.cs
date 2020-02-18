using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallDir : MonoBehaviour
{
    public bool placed = false;
    float DestroyTimer;
    float TimeToDestroy;

    MyCharacerControllerP2 playerScript2;
    MyCharacterController playerScript;

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

        if (other.gameObject.tag == "ball" && placed == true)
        {
            Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
            float randVal = Random.Range(-1f, 1.1f);

            Vector3 ballT = new Vector3(0, randVal, 0);



            rb2d.AddForce(ballT * 20.0f, ForceMode2D.Impulse);


            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 10 && placed == false)
        {
            if (other.gameObject.tag == "Player")
            {
                 playerScript = other.GetComponent<MyCharacterController>();

            }
            else if (other.gameObject.tag == "Player2")
            {
                playerScript2 = other.GetComponent<MyCharacerControllerP2>();

            }
            if (playerScript)
            {
                if (playerScript.changeballdirPU <= 2)
                {
                    playerScript.changeballdirPU += 1;
                }
                else
                {
                    playerScript.changeballdirPU = 2;
                }
            } else if (playerScript2)
            {
                if (playerScript2.changeballdirPU <= 2)
                {
                    playerScript2.changeballdirPU += 1;
                }
                else
                {
                    playerScript2.changeballdirPU = 2;
                }
            }

            Destroy(gameObject);

        }

    }
}
