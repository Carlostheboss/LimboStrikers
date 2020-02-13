using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{

    public float pushPower;
    private IEnumerator pusherCourotine;
    private IEnumerator coolDownCourotine;
    private bool pusherActive;
    private bool canPush;

    // Start is called before the first frame update
    void Start()
    {
        pusherActive = false;
        canPush = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (pusherActive)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }

        if(!canPush)
        {
            coolDownCourotine = Cooldown(2f);
            StartCoroutine(coolDownCourotine);

        }

        if (Input.GetKeyDown(KeyCode.K) && canPush)
        {
            Debug.Log("k pressed");

            pusherActive = true;
            pusherCourotine = ActivateDeactivatePusher(1); // stays active for x seconds
            StartCoroutine(pusherCourotine);
        }

        

    }
    
    private IEnumerator ActivateDeactivatePusher(float timer)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);
            pusherActive = false;
            canPush = false;



        }
    }

    private IEnumerator Cooldown(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            canPush = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");


        if (collision.gameObject.tag == "ball")
        {

            Debug.Log("touch ball");

            var dir = transform.position - collision.transform.position;

            dir = -dir.normalized;

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * pushPower);
        }

    }
}
