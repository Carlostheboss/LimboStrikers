using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RandomStuff : MonoBehaviour
{

	public GameObject[] PowerUp;
	public int MaxRangeX;
	public int MinRangeX;
	public int MaxRangeY;
	public int MinRangeY;
	float PUTimer = 10.0f;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		PUTimer -= Time.deltaTime;

		if(PUTimer < 0)
		{
			int x = Random.Range(MinRangeX, MaxRangeX);
			int y = Random.Range(MinRangeY, MaxRangeY);

			int PUR = Random.Range(0, PowerUp.Length);

			Vector3 pos = new Vector3(x, y, 10f);

			Instantiate(PowerUp[PUR], pos, Quaternion.identity, transform);

			PUTimer = 10.0f;
		}

    }
}
