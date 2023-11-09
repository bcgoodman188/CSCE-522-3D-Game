using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] pos;
    public PlayerData(PlayerMove player) 
    {
        health = player.health;

        pos = new float[3];
        pos[0] = player.transform.position.x;
        pos[1] = player.transform.position.y;
        pos[2] = player.transform.position.z;
    }
}
