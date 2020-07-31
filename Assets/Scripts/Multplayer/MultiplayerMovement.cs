using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;


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

   public GameObject vcam;


   //Public objects
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 30f;

    private bool allowFire = true;

    public float fireRate = 0.75f;

    [SyncVar]
    public bool canMove; 

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        cam = Camera.main;

        GameObject vCam = GameObject.Find("CM vcam1");
        vCam.GetComponent<PlayerCameraController>().player = gameObject;
        vCam.GetComponent<PlayerCameraController>().isFound = true; 

    }

   

    //Only run code client side 
    [Client]
    // Update is called once per frame
    void Update()
    {
        //Camera.main.transform.localEulerAngles = new Vector3(0f,0f,0f);
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

        if(Input.GetButtonDown("Fire1") && allowFire)
        {
            CmdShoot();
            StartCoroutine(ShootTimer());
        }
        
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

     [Command]
    void CmdShoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<MPArrow>().shooter = gameObject;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        NetworkServer.Spawn(arrow);
    }

    IEnumerator ShootTimer()
    {

        allowFire = false;
        yield return new WaitForSeconds(fireRate);
        allowFire = true;

    }
}
