using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    
    void Start()
    {
        finalScore.text = "Final Score: " + GameManager.score.ToString();
    }
}
