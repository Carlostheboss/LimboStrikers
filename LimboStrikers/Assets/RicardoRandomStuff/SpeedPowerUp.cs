using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpeedPowerUp : MonoBehaviour
{
	float DestroyTimer;
	float TimeToDestroy;
    public GameObject VFXSpeedPU;


    // Start is called before the first frame update
    void Start()
    {
		DestroyTimer = Time.time;
		TimeToDestroy = DestroyTimer + 5.0f;
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

        if (other.gameObject.layer == 10)
        {
            Instantiate(VFXSpeedPU, transform.position, Quaternion.identity);

            GameObject player = other.gameObject;
            if (player.name == "PlayerA")
            {
                GameObject playera = GameObject.Find("PlayerA");
                MyCharacterController playerScript = playera.GetComponent<MyCharacterController>();

                playerScript.speed = playerScript.speed * 1.5f;
                Destroy(gameObject);
            }
            else if (player.name == "PlayerD")
            {
                GameObject playerd = GameObject.Find("PlayerD");
                MyCharacerControllerP2 playerScript = playerd.GetComponent<MyCharacerControllerP2>();

                playerScript.speed = playerScript.speed * 1.5f;
                Destroy(gameObject);
            }
        }

    }

}


