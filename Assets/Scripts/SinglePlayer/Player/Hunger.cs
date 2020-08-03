using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
   //public bool gameReady;
    public bool gameStarted;
    public float hunger;

    //public Text cdText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  // if(gameReady && !gameStarted)
        //{
           // StartCoroutine(Countdown());
        //}
        if (gameStarted)
        {
            HungerDown();
        }
    }

    //Method which decreases hunger
    private void HungerDown()
    {
        hunger -= Time.deltaTime;
    }

    //Wait 5 seconds before hunger goes down
   /* IEnumerator Countdown()
    {
        cdText.text = "3";
        yield return new WaitForSeconds(1f);
        cdText.text = "2";
        yield return new WaitForSeconds(1f);
        cdText.text = "1";
        yield return new WaitForSeconds(1f);
        cdText.text = "Go!"; 
        gameStarted = true;
        yield return new WaitForSeconds(1f);
        cdText.text = "";
    }
    */
}
