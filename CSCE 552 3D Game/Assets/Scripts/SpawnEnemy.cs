using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private float nextActionTimer = 0.0f;
    public float endTimer = 5.0f;
    
    void Start() {
        InvokeRepeating("spawn", 2.0f, 5.0f);
    }
    // Update is called once per frame
    void Update(){
        
    }
    void spawn() {
        GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
    }
}
