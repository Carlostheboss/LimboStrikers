using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreingGoal : MonoBehaviour
{


    public Text ScoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding");

        if(collision.gameObject.tag == "ball")
        {
            Debug.Log(score);
            score += 1;

            ScoreText.text = score.ToString();
        }
    }

}
