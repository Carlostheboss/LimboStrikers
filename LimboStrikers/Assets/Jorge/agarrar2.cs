using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar2 : MonoBehaviour
{
    private MyCharacerControllerP2 character;

    private void Start()
    {
        character = MyCharacerControllerP2.instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("trigger 1");
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("trigger 2");

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                Debug.Log("trigger 3");

                character.press = true;

                if (character.press)
                    Debug.Log("press");
            }
        }
    }
}
