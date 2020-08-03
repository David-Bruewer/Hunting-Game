using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyLoader 
{
   public static bool isFull = false;

    //Array of amount of enemies loaded 
   private static int[] enemiesLoaded = new int[] {0,0,0,0,0,0};

    //Adds enemy 
   public  static void addEnemy()
   {
        for (int i = 0; i < enemiesLoaded.Length; i++)
        {
            if (enemiesLoaded[i] == 0) 
            {
                enemiesLoaded[i] = 1; 
                i += enemiesLoaded.Length;
            }
        }

        if (enemiesLoaded[enemiesLoaded.Length -1] == 1)
        {
            isFull = true; 
        }else
        {
            isFull = false; 
        }
        

   }

   //Removes enemy 
   public static void removeEnemy()
   {
        for (int i = enemiesLoaded.Length -1; i >= 0; i--)
        {
            if (enemiesLoaded[i] == 1) 
            {
                enemiesLoaded[i] = 0; 
                i = 0;
            }
        }
        isFull = false;
   }
}
