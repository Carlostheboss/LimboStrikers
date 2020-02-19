using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GoalCounterA GoalCounterA;
    public GoalCounterD GoalCounterD;
    private int setsP1 = 0;
    private int setsP2 = 0;
    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public Animator WinAnimP1;
    public Animator WinAnimP2;
    public Image Set1P1;
    public Image Set2P1;
    public Image Set1P2;
    public Image Set2P2;
    public GameObject BallSpawner;
    public GameObject BallSpawner2;
    public GameObject BallSpawner3;
    public Animator BallSpawnerAnim;
    public Animator BallSpawner2Anim;
    public Animator BallSpawner3Anim;
    public GameObject StartText;
    public Animator StarttextAnim;
    public GameObject restart;
    public AudioSource HeavenWinsAudio;
    public AudioSource HellWinsAudio;

    // Start is called before the first frame update
    void Start()
    {
        BallSpawner.SetActive(true);
        BallSpawnerAnim.Play(0);
        BallSpawner2.SetActive(true);
        BallSpawner2Anim.Play(0);
        BallSpawner3.SetActive(true);
        BallSpawner3Anim.Play(0);

        StartText.SetActive(true);
        StarttextAnim.Play(0);
    }

    public void Restart()
    {
        GoalCounterD.numberofgoalsplayer1 = 0;
        GoalCounterA.numberofgoalsplayer2 = 0;
        setsP1 = 0;
        setsP2 = 0;
        Set1P1.color = new Vector4(Set1P1.color.r, Set1P1.color.b, Set1P1.color.g, 0.3f);
        Set2P1.color = new Vector4(Set2P1.color.r, Set2P1.color.b, Set2P1.color.g, 0.3f);
        Set1P2.color = new Vector4(Set1P2.color.r, Set1P2.color.b, Set1P2.color.g, 0.3f);
        Set2P2.color = new Vector4(Set2P2.color.r, Set2P2.color.b, Set2P2.color.g, 0.3f);

        PlayerOne.transform.position = new Vector3(GoalCounterA.transform.position.x + 4, GoalCounterA.transform.position.y, 8);
        PlayerTwo.transform.position = new Vector3(GoalCounterD.transform.position.x - 4, GoalCounterD.transform.position.y, 10);

        BallSpawner.SetActive(true);
        BallSpawnerAnim.Play(0);
        BallSpawner2.SetActive(true);
        BallSpawner2Anim.Play(0);
        BallSpawner3.SetActive(true);
        BallSpawner3Anim.Play(0);

        StartText.SetActive(true);
        StarttextAnim.Play(0);

        PlayerOne.SetActive(true);
        PlayerTwo.SetActive(true);

        restart.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (GoalCounterA.numberofgoalsplayer2 == 5 && setsP1 != 1)
        {
            GoalCounterD.numberofgoalsplayer1 = 0;
            GoalCounterA.numberofgoalsplayer2 = 0;
            setsP1 += 1;
        }
        if (GoalCounterA.numberofgoalsplayer2 == 5 && setsP1 == 1)
        {  
            setsP1 += 1;
        }
        if (GoalCounterD.numberofgoalsplayer1 == 5 && setsP2 != 1)
        {
            GoalCounterD.numberofgoalsplayer1 = 0;
            GoalCounterA.numberofgoalsplayer2 = 0;
            setsP2 += 1;
        }
        if (GoalCounterD.numberofgoalsplayer1 == 5 && setsP2 == 1)
        {
            setsP2 += 1;
        }
        if (setsP1 == 1)
        {
            P2Win.SetActive(true);
            WinAnimP2.Play(0);
           Set1P2.color = new Vector4(Set1P2.color.r, Set1P2.color.b, Set1P2.color.g, 1);
        }
        if (setsP1 == 2)
        {
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
            HeavenWinsAudio.PlayOneShot(HeavenWinsAudio.clip, HeavenWinsAudio.volume);
            P2Win.SetActive(false);
            P2Win.SetActive(true);
            WinAnimP2.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
            Set2P2.color = new Vector4(Set2P2.color.r, Set2P2.color.b, Set2P2.color.g, 1);
            restart.SetActive(true);
        }
        if (setsP2 == 1)
        {
            P1Win.SetActive(true);
            WinAnimP1.Play(0);       
            Set1P1.color = new Vector4(Set1P1.color.r, Set1P1.color.b, Set1P1.color.g, 1);
        }
        if(setsP2 == 2)
        {
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
            HellWinsAudio.PlayOneShot(HellWinsAudio.clip, HellWinsAudio.volume);
            P1Win.SetActive(false);
            P1Win.SetActive(true);
            WinAnimP1.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
            Set2P1.color = new Vector4(Set2P1.color.r, Set2P1.color.b, Set2P1.color.g, 1);
            restart.SetActive(true);
        }
    }
}
