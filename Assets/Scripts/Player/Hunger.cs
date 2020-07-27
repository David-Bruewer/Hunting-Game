using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{

    public float hunger = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        HungerDown();
    }

    //Method which decreases hunger
    private void HungerDown()
    {
        hunger -= Time.deltaTime;
    }

    //Wait 5 seconds before hunger goes down
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
    }
}
