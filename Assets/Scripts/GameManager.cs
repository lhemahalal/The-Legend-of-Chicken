using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // if we want to add audio
    // public AudioSource music;
    // public bool startPlaying; 

    public int arrowsLeft;
    private int totalArrows;
    public int playerScore;
    public int pointsPerHit;
    public bool win;
    public bool reset;

    public static GameManager instance;
    public GameObject struggleState;
    public ArrowScroller scroller;
    public PlayerMovement player;
    public LinkController enemy;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalArrows = arrowsLeft;
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore == totalArrows)
        {
            win = true;
        }

        if (arrowsLeft <= 0)
        {
            struggleState.SetActive(false);
            reset = true;
            Reset();
        }
    }

    public void OnHit()
    {
        playerScore += pointsPerHit;
    }

    public void Reset()
    {
        arrowsLeft = totalArrows;
        playerScore = 0;
        win = false;
        scroller.ResetPosition();
    }

    public void GameHalt()
    {
        player.pause = true;
        enemy.pause = true; 
    }

    public void GameResume()
    {
        player.pause = false;
        enemy.pause = false;
    }
}
