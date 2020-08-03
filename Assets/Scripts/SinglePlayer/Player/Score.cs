using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.GetComponent<Hunger>().hunger.ToString("f2");
        if(scoreText.text == "0.02")
        {
            scoreText.text = "0.00";
        }
    }
}
