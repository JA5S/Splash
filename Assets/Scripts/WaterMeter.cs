using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//adjusts slider water level, and triggers win condition
public class WaterMeter : MonoBehaviour
{
    //variables
    public Slider slider;
    [SerializeField] int maxWater = 10;
    public bool gameOver;
    public GameObject gameOverMenu;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI waterCounter;

    void Start()
    {
        slider.maxValue = maxWater;
    }

    private void Update()
    {
        waterCounter.text = (maxWater - slider.value).ToString();
        if(slider.value == maxWater)
        {
            gameOver = true;
            gameOverText.text = "Game Over! You Win!";
            Debug.Log("You Win");
        }

        //end the game
        if (gameOver == true)
        {
            gameOverMenu.SetActive(true);
        }
    }
    public void IncreaseWater()
    {
        slider.value++;
    }
}
