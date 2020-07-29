using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
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
            StartCoroutine( Shoot());
        }
        
    }

    IEnumerator Shoot()
    {

        allowFire = false;

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<Arrow>().shooter = gameObject;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(fireRate);
        allowFire = true;

    }
}
