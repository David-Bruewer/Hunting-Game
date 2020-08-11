using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Controls Countdown textbox before game 
public class CountdownController : MonoBehaviour 
{
    //Textbox for countdown
    public Text CD; 
    
    //Countdown function to be called externally 
    public void StartCount()
    {
        StartCoroutine(Countdown());
    }

    //Coroutine called to start a 3 second countdown 
    IEnumerator Countdown()
    {
        CD.text = "3"; 
        yield return new WaitForSeconds(1f);
        CD.text = "2"; 
        yield return new WaitForSeconds(1f);
        CD.text = "1"; 
        yield return new WaitForSeconds(1f);
        CD.text = "GO!"; 
        yield return new WaitForSeconds(1f);
         CD.text = ""; 
    }

}
