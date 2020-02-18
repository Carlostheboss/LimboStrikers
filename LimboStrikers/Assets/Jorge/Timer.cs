using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float currentTime = 0.0f;
    public float startingTime = 0.5f;

    private MyCharacterController character;

    void Start()
    {
        character = MyCharacterController.instance;
        currentTime = startingTime;
    }


    void Update()
    {
        if (character.timer == true)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                character.timer = false;
                character.currentEulerAngles = new Vector3(0f, 0f, 0f);
                character.currentRotation.eulerAngles = character.currentEulerAngles;
                character.transform.rotation = character.currentRotation;
            }
        }
        else
        {
            currentTime = startingTime;
        }
    }
}
