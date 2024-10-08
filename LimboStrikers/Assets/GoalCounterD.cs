﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCounterD : MonoBehaviour
{
    public int numberofgoalsplayer1 = 0;
    public Text Player1Score;
    public GameObject Goal;
    public Animator GoalAnim;
    public GameObject BallRespawn;
    public GameObject BallSpawner;
    public GameObject BallSpawner2;
    public GameObject BallSpawner3;
    public Animator BallSpawnerAnim;
    public Animator BallSpawner2Anim;
    public Animator BallSpawner3Anim;
    public GameObject PlayerARespawn;
    public AudioSource GoalAudio;
    // Start is called before the first frame update
    void Start()
    {
        Player1Score.text = "P1 Goals: " + numberofgoalsplayer1.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Player1Score.text = "P1 Goals: " + numberofgoalsplayer1.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            GoalAudio.PlayOneShot(GoalAudio.clip, GoalAudio.volume);
            numberofgoalsplayer1 += 1;
            if (numberofgoalsplayer1 != 5)
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
                GameObject.Find("PlayerD").transform.position = new Vector3(transform.position.x - 10, transform.position.y - 1, 6);
                GameObject.Find("PlayerA").transform.position = new Vector3(PlayerARespawn.transform.position.x , PlayerARespawn.transform.position.y - 1,6);
         
        }
    }
}
