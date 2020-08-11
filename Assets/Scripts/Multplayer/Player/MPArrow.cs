﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Class which defines Arrow behavior on Server 
public class MPArrow : NetworkBehaviour
{
    //Amount of time arrow exists
    public float arrowSpawn = 0.5f;

    //Player who shot bullet
    public GameObject shooter; 


    void OnCollisionEnter2D(Collision2D collision)
    {
        //if Mole is shot, add 10 (make changeable later?)
        if(collision.gameObject.tag == "Mole"){
            shooter.GetComponent<Hunger>().hunger +=5; 
            Debug.Log(shooter.GetComponent<Hunger>().hunger);
        }
        
        
        Destroy(gameObject);
        

                
    }
    void Update()
    {
        Destroy(gameObject,arrowSpawn);
    }
}