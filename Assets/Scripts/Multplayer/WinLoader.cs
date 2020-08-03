using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoader : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject youWin;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerData.didWin)
        {
            gameOver.SetActive(false);
            youWin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerData.didWin = false;
        
    }
}
