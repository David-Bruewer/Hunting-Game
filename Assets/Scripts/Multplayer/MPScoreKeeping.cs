using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MPScoreKeeping : NetworkBehaviour
{
    public GameObject player; 
    bool disconnected; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disconnected) {return;}
        if (player.GetComponent<Hunger>().hunger <= 0)
        {
            player.GetComponent<NetworkIdentity>().connectionToServer.Disconnect();
            disconnected = true;
        }
        
    }
}
