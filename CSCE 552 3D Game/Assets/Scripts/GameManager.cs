using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;
    public static int score = 0;
    public static int timerMin = 2;
    public static int timerSecOne = 0;
    public static int timerSecTwo = 0;
    public static int wave = 0;
    public static int health = 100;
    void Update() {
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Timer: " + timerMin.ToString() + ":" + timerSecOne.ToString() + "" + timerSecTwo.ToString();
        waveText.text = "Wave: " + wave.ToString();
        healthText.text = "Health: " + health.ToString();
    }
}
