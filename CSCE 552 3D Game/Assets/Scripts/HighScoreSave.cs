using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreSave : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public static int highScore;
    
    void Start()
    {
        if(highScore <= 0) {
            highScoreText.text = "High Score: None";
        }
        if(highScore > 0) {
            highScoreText.text = "High Score: " + highScore;
        }
    }
    
   
}
