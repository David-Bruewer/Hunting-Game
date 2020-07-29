using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour
{
   public Text finalScoreText;
    
    void Update()
    {
        finalScoreText.text = "You survived " + ScoreKeeping.time.ToString("f2") + " seconds";
    }
}
