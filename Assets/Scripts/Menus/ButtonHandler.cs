using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    //Starts the game from the start menu
   public void StartSinglePlayerGame()
   {
        SceneManager.LoadScene(1); 
        Debug.Log("button clicked");
   }

   public void StartMultiplayerGame()
   {
       SceneManager.LoadScene(3);
   }

    //Exits game 
   public void ExitGame()
   {
       Application.Quit();
   }

   //Goes to main menu 
   public void MainMenu()
   {
       SceneManager.LoadScene(0);
   }
}
