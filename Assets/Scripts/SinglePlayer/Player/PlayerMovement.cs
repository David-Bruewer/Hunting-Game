using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

   public bool canMove; 

   

    // Update is called once per frame
    void Update()
    {
        if(!canMove){return;}
        //player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Aiming 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        //Move
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime);

        //Aim
        Vector2 lookDir = mousePos - rb.position; 
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
