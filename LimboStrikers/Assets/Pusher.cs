﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{

    public float pushPower;
    private IEnumerator pusherCourotine;
    private IEnumerator coolDownCourotine;
    private bool pusherActive;
    private bool canPush;
    private CameraShake shake;

    public float pusherTimer;

    private float nextPush;

    public AudioSource HittingPlayerSound;

    // Start is called before the first frame update
    void Start()
    {
        shake = CameraShake.instance;
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

            HittingPlayerSound.PlayOneShot(HittingPlayerSound.clip, HittingPlayerSound.volume);
            Debug.Log("touch ball");

            var dir = transform.position - collision.transform.position;

            dir = -dir.normalized;

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * pushPower);

            shake.TriggerShake(.3f, .2f);
        }

    }
}
