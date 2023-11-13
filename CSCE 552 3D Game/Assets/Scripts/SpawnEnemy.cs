using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject blueEnemy;
    
    void Start() {
        InvokeRepeating("spawn", 2.0f, 5.0f);
    }
    // Update is called once per frame
    void Update(){
        
    }
    void spawn() {
        int rand = Random.Range(1,4);
        switch(rand) {
            case 1:
            GameObject redClone = Instantiate(redEnemy, transform.position, transform.rotation);
            break;
            case 2:
            GameObject greenClone = Instantiate(greenEnemy, transform.position, transform.rotation);
            break;
            case 3:
            GameObject blueClone = Instantiate(blueEnemy, transform.position, transform.rotation);
            break;
        }
    }
}
