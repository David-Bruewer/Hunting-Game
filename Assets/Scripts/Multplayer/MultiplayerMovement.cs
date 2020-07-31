using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class MultiplayerMovement : NetworkBehaviour
{
   
   //Player speed 
   public float moveSpeed = 5f; 

    //Player rigidbody 
   public Rigidbody2D rb; 

   //Camera
   public Camera cam;

    //Movement vector
   Vector2 movement;

   //Aim Vector
   Vector2 mousePos; 

    [SyncVar]
    public bool canMove; 


   

    //Only run code client side 
    [Client]
    // Update is called once per frame
    void Update()
    {
        //Checks authority to only move 1 player 
        if(!isLocalPlayer){return;}

        //checks if round can start 
        if (!canMove){return;}
        //player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //Debug.Log(NetworkManager.networkAddress);

        //Aiming 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }


    //Only run code client side 
    [Client]
    void FixedUpdate()
    {
        //Checks authority to only move 1 player 
        if(!isLocalPlayer){return;}

        //checks if round can start 
        if (!canMove){return;}

        //Move
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime);
        

        //Aim
        Vector2 lookDir = mousePos - rb.position; 
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}