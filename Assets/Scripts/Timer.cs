using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//updates timer text and applies lose condition
public class Timer : MonoBehaviour
{

    //declare variables
    public TextMeshProUGUI timer;
    public WaterMeter waterMeter;
    public float timeLeft = 60;
    public GameManager gameManager;
    public TextMeshProUGUI gameOverText;
    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= timeLeft && gameManager.gameHasStarted)
        {
            waterMeter.gameOver = true;
            gameOverText.text = "Game Over! You Lose.";
            Debug.Log("You Lose");
        }
        //update timer
        if(!waterMeter.gameOver && gameManager.gameHasStarted)
        {
            timer.text = (timeLeft - Time.timeSinceLevelLoad + gameManager.timeStarted).ToString("0");
        }
    }
}
