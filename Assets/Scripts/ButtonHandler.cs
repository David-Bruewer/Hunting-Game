﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    //Starts the game from the start menu
   public void StartGame()
   {
        SceneManager.LoadScene(1); 
   }
}
