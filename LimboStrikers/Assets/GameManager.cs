using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GoalCounterA GoalCounterA;
    public GoalCounterD GoalCounterD;
    private int setsP1;
    private int setsP2;
    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public Animator WinAnimP1;
    public Animator WinAnimP2;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        if (GoalCounterD.numberofgoalsplayer1 == 5)
        {
            P2Win.SetActive(true);
            WinAnimP2.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
        }
        if (GoalCounterA.numberofgoalsplayer2 == 5)
        {
            P1Win.SetActive(true);
            WinAnimP1.Play(0);
            PlayerOne.SetActive(false);
            PlayerTwo.SetActive(false);
        }
    }
}
