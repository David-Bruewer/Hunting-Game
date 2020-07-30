using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class RoundSystem 
{
    // boolean if the round can start
    public static bool canStart; 

    public static bool playerWon;

    //Starts the round 
    public static IEnumerator StartRound()
    {
        yield return new WaitForSeconds(3f);
        canStart = true; 
        Debug.Log("Totally!");
        
    }

    public static void EndRound()
    {
        canStart = false;
    }

    
}
