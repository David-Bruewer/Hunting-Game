using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour 
{
    // Start is called before the first frame update
    public Text CD; 

    public void StartCount()
    {
        StartCoroutine(Countdown());
    }

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
