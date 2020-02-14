﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPowerUp : MonoBehaviour
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

		if (other.gameObject.tag == "Player")
		{
			GameObject player = other.gameObject;
			if( player.name == "PlayerD") 
			{
				GameObject playera = GameObject.Find("PlayerA");
				MyCharacterController playerScript = playera.GetComponent<MyCharacterController>();

				playerScript.speed = playerScript.speed / 2;
				Destroy(gameObject);
			}
			else if (player.name == "PlayerA")
			{
				GameObject playerd = GameObject.Find("PlayerD");
				MyCharacterController playerScript = playerd.GetComponent<MyCharacterController>();

				playerScript.speed = playerScript.speed / 2;
				Destroy(gameObject);
			}
		}

	}


}
