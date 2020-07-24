using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        ScoreKeeping.time = timer;
        if(player.GetComponent<Hunger>().hunger <= 0f){
            LoadGameOver();
        }
    }

    public void LoadGameOver(){
       SceneManager.LoadScene(2); 
    }
}
