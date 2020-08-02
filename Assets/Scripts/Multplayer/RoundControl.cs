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

    
    public List<MultiplayerMovement> players = new List<MultiplayerMovement>();
    public int minPlayers = 2;

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
        Debug.Log(players.Count);

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
                    Debug.Log("penis");
                }
                
                players.Clear();
                isGameReady = false;
            }
        }
    }

    private IEnumerator countdown()
    {
        mainBox.text = "3";
        yield return new WaitForSeconds(1f); 
        mainBox.text = "2";
        yield return new WaitForSeconds(1f);
        mainBox.text = "1";
        yield return new WaitForSeconds(1f);
        mainBox.text = "GO!";
        isGameReady = true; 
        foreach(MultiplayerMovement mm in players)
            {
                mm.canMove = true;
                    
            }
        yield return new WaitForSeconds(1f);
        mainBox.text = "";
         
    }
}
