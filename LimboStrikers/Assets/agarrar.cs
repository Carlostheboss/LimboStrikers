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

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("cheguei caralho 1");
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("cheguei caralho 2");

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("cheguei caralho 3");

                character.press = true;

                if (character.press)
                    Debug.Log("press");
            }
        }
    }
}
