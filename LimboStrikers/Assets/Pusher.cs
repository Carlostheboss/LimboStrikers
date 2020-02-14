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

    public float pusherTimer;

    private float nextPush;

    // Start is called before the first frame update
    void Start()
    {
        pusherActive = false;
        canPush = true;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, pusherTimer);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
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
