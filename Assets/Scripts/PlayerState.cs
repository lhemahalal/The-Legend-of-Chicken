using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{ 
    //define player states
    public enum playerState
    {
        EscapeState,
        StruggleState,
        AttackState
    }

    public playerState currentState;
    public GameObject struggleState;
    public GameObject chickenSwarm; 

    //define reference time-variable
    private float lastStateChange = 0.0f;


    //define method for setting the state of playerState
    void setCurrentState(playerState state)
    {
        currentState = state;
        lastStateChange = Time.time;
    }


    // Use this for initialization
    void Start()
    {
        setCurrentState(playerState.EscapeState); //call function to set state
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case playerState.EscapeState:
                //resume player & enemy
                // GameManager.instance.GameResume(); 

                break;
            case playerState.StruggleState:
                // halt player & enemy
                // GameManager.instance.GameHalt();
                // GameManager.instance.reset = false; 

                // begin ddr minigame with difficulty based on rupee points
                struggleState.SetActive(true);

                // StartCoroutine(MiniGame());

                // struggleState.SetActive(false);

                // if player wins, enter attack state + enemy loses health
                if (GameManager.instance.win == true)
                 {
                  setCurrentState(playerState.AttackState);
                  EnemyHealth.health--;
                 }
                 
                 // if player loses, enter escape state + player loses health
                 else if (GameManager.instance.win == false)
                 {
                   setCurrentState(playerState.EscapeState);
                   PlayerHealth.health--;
                 }

                break;
            case playerState.AttackState:
                //resume player & enemy
                // GameManager.instance.GameResume();

                chickenSwarm.SetActive(true); 

                //time limit : 20 seconds
                //cucco swarm
                //player state returns to escape state when time is up

                break;
            default:
                break; 
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && currentState == playerState.EscapeState)
        {
            Debug.Log("Player caught by enemy");
            setCurrentState(playerState.StruggleState);

            //pause game
            //enter struggle state

            //if chicken wins, chicken enters attack state
            //if chicken loses, enter escape state and lose health
            
        }
        else if (col.gameObject.tag == "Enemy" && currentState == playerState.AttackState)
        {
            Debug.Log("Enemy caught by player");
            EnemyHealth.health--;
         }
    }

    IEnumerator MiniGame()
    {
        yield return new WaitUntil(() => GameManager.instance.arrowsLeft == 0);
    }
}

