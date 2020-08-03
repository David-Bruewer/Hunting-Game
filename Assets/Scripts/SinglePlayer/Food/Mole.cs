using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
   Vector2 movement; 
   private bool canMove = true;

   public Rigidbody2D rb;  

   public float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            StartCoroutine(Walk());
        }
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);

            EnemyLoader.removeEnemy();
        }      
    }

    IEnumerator Walk()
    {   
        canMove = false;
        movement.x = Random.Range(0,3) -1;
        movement.y = Random.Range(0,3) -1;
        yield return new WaitForSeconds(3f);
        canMove = true; 
    }
}
