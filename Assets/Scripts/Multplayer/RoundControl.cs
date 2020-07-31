using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RoundControl : MonoBehaviour
{
    
    public bool isGameReady; 
    public List<MultiplayerMovement> players = new List<MultiplayerMovement>();
    public int minPlayers = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameReadyCheck();
    }

    public void gameReadyCheck()
    {
        if(!isGameReady)
        {
             foreach (KeyValuePair<uint, NetworkIdentity> kvp in NetworkIdentity.spawned)
                {
                    MultiplayerMovement comp = kvp.Value.GetComponent<MultiplayerMovement>();
                    if (comp != null)
                    {
                        if (!players.Contains(comp))
                        {
                            //Add if new
                            players.Add(comp);
                            
                        }
                    }
                }

            if(players.Count == minPlayers)
            {
                isGameReady = true;
                foreach(MultiplayerMovement mm in players)
                {
                    mm.canMove = true; 
                }
            }
        }
    }
}
