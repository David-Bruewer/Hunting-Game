using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MPShooting : NetworkBehaviour
{
  //Public objects
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 30f;

    private bool allowFire = true;

    public float fireRate = 0.75f;
    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && allowFire)
        {
            CmdShoot();
            StartCoroutine(ShootTimer());
        }
        
    }

    [Command]
    void CmdShoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        NetworkServer.Spawn(arrow);
        arrow.GetComponent<Arrow>().shooter = gameObject;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }

    IEnumerator ShootTimer()
    {

        allowFire = false;
        yield return new WaitForSeconds(fireRate);
        allowFire = true;

    }
}
