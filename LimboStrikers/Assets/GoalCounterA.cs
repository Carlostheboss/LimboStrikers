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
    public GameObject BallRespawn;
    public GameObject BallSpawner;
    public GameObject BallSpawner2;
    public GameObject BallSpawner3;
    public Animator BallSpawnerAnim;
    public Animator BallSpawner2Anim;
    public Animator BallSpawner3Anim;
    public GameObject PlayerDRespawn;
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
            if (numberofgoalsplayer2 != 5)
            {
                Goal.SetActive(true);
          
                GoalAnim.Play(0);
            }
            BallSpawner.SetActive(true);
            BallSpawnerAnim.Play(0);
            BallSpawner2.SetActive(true);
            BallSpawner2Anim.Play(0);
            BallSpawner3.SetActive(true);
            BallSpawner3Anim.Play(0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collision.gameObject.transform.position = BallRespawn.transform.position;
                GameObject.Find("PlayerA").transform.position = new Vector3(transform.position.x + 4, transform.position.y, 10);
                GameObject.Find("PlayerD").transform.position = new Vector3(PlayerDRespawn.transform.position.x, PlayerDRespawn.transform.position.y, 10);
            
           }
    }
}
