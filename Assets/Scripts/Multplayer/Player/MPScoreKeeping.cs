using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Keeps track of the players score while connected 
public class MPScoreKeeping : NetworkBehaviour
{
    //Player Game object 
    public GameObject player; 

    //Boolean which checks if the player is disconnected 
    bool disconnected; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //If Player is connected and their hunger reaches 0, disconnect 
        if (disconnected) {return;}
        if (player.GetComponent<Hunger>().hunger <= 0)
        {
            player.GetComponent<NetworkIdentity>().connectionToServer.Disconnect();
            disconnected = true;
        }
        
    }
}
