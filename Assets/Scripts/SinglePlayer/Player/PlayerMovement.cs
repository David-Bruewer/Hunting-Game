using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

   public Text CDText;

   private void Start() 
   {
       CDText.GetComponent<CountdownController>().StartCount();
       StartCoroutine(ThreeSeconds());

   }

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

    IEnumerator ThreeSeconds()
    {
        yield return new WaitForSeconds(3f);
        canMove = true; 
        gameObject.GetComponent<Hunger>().gameStarted = true;
    }
}
