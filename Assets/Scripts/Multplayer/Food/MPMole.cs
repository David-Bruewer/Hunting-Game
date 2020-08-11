using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Class which defines the behavior of the Mole enemy while Online 
public class MPMole : NetworkBehaviour
{

    //Movement Vector
    Vector2 movement;
    
    //boolean to check if mole can move 
    private bool canMove = true;

    //Mole rigidbody 
    public Rigidbody2D rb;  

    //Moles Movement Speed 
    public float moveSpeed = 5f;

    
    // Update is called once per frame
    void Update()
    {
        //If mole can walk, start walking 
        if (canMove)
        {
            StartCoroutine(Walk());
        }
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        
    }

    //Called if mole collides with object 
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If mole is shot, despawn  
        if(collision.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);

            EnemyLoader.removeEnemy();
        }      
    }

    //Walking Coroutine, walks in one direction for 3 seconds then changes direction 
    IEnumerator Walk()
    {   
        canMove = false;
        movement.x = Random.Range(0,3) -1;
        movement.y = Random.Range(0,3) -1;
        yield return new WaitForSeconds(3f);
        canMove = true; 
    }
}

