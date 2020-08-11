using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Class which defines shooting while multiplayer 
public class MPShooting : NetworkBehaviour
{
    //Point which arrow shoots from 
    [SyncVar]
    public Transform firePoint;

    //Arrow prefab 
    public GameObject arrowPrefab;

    //Force and speed of arrow when fired 
    public float arrowForce = 30f;

    //Boolean if arrow can be fired 
    private bool allowFire = true;

    //Rate at which arrow can be shot 
    public float fireRate = 0.75f;

    // Update is called once per frame
    void Update()
    {
        //Checks if mouse has been clicked and firing is allowed 
        if(Input.GetButtonDown("Fire1") && allowFire)
        {
            //Tells the server to shoot arrow 
            CmdShoot();
            StartCoroutine(ShootTimer());
        }
        
    }

    //Command which tells arrow to instantiate and spawn arrow 
    [Command]
    void CmdShoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<MPArrow>().shooter = gameObject;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        NetworkServer.Spawn(arrow);
    }

    //Time which only allows shooting after a delay of time 
    IEnumerator ShootTimer()
    {

        allowFire = false;
        yield return new WaitForSeconds(fireRate);
        allowFire = true;

    }
}
