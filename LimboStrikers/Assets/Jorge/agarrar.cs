using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    private MyCharacterController character;

    private void Start()
    {
        character = MyCharacterController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("trigger 1");
        if (collision.gameObject.tag == "ball")
        {

            //Debug.Log("trigger 2");

            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("trigger 3");

                character.press = true;
                character.touch = true;

                if (character.press)
                    Debug.Log("press");
            }
        }
    }
}
