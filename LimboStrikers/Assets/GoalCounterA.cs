using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCounterA : MonoBehaviour
{
    public int numberofgoalsplayer2 = 0;
    public Text Player2Score;
    public GameObject Goal;
    public Animator GoalAnim;
    // Start is called before the first frame update
    void Start()
    {     
        Player2Score.text = "P2 Goals: " + numberofgoalsplayer2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Player2Score.text = "P2 Goals: " + numberofgoalsplayer2.ToString();
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            numberofgoalsplayer2 += 1;
            Goal.SetActive(true);
            GoalAnim.Play(0);
        }
    }
}
