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

    // Start is called before the first frame update
    void Start()
    {
    
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
            P2Win.SetActive(false);
            P2Win.SetActive(true);
            WinAnimP2.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
     
            Set2P2.color = new Vector4(Set2P2.color.r, Set2P2.color.b, Set2P2.color.g, 1);

        }
        if (setsP2 == 1)
        {
            P1Win.SetActive(true);
            WinAnimP1.Play(0);
        

         
                Set1P1.color = new Vector4(Set1P1.color.r, Set1P1.color.b, Set1P1.color.g, 1);
         



        }
        if(setsP2 == 2)
        {
            P1Win.SetActive(false);
            P1Win.SetActive(true);
            WinAnimP1.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);

            Set2P1.color = new Vector4(Set2P1.color.r, Set2P1.color.b, Set2P1.color.g, 1);

        }
    }
}
