using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RoundControl : NetworkBehaviour
{
    //For is game Ready 
    [SyncVar]
    public bool isGameReady; 

    [SyncVar]
    public int numPlayers;     
    public List<MultiplayerMovement> players = new List<MultiplayerMovement>();
    public int minPlayers;

    public Text mainBox; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameReadyCheck();
        gameOverCheck();
        //Debug.Log(players.Count);
        //Debug.Log(isGameReady);

    }

    public void gameReadyCheck()
    {
        if(!isGameReady)
        {

            if(players.Count == minPlayers)
            {
                
                StartCoroutine(countdown());
            }
        }
    }

    public void gameOverCheck()
    {
        if (isGameReady)
        {
            if(players.Count <= 1)
            {
                foreach (MultiplayerMovement mm in players) 
                {
                    mm.hasWon = true;
                }
                
                players.Clear();
                isGameReady = false;
            }
        }
    }

    private IEnumerator countdown()
    {   
        foreach(MultiplayerMovement mm in players)
            {
                mm.countdown = true;
                    
            }
        
        yield return new WaitForSeconds(3f);
        foreach(MultiplayerMovement mm in players)
            {
                mm.canMove = true;
                    
            }

            isGameReady = true;
      
         
    }
}
