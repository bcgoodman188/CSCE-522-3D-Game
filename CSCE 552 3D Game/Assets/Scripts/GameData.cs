using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public int wave;
    public int score;
    public GameData(GameManager game) {
        health = game.healthSave;
        wave = game.waveSave;
        score = game.scoreSave;
    }
}
