using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubtEnemy : EnemyOne
{
    void Update() {
        transform.LookAt(playerPos);

        float distance = Vector3.Distance(transform.position, playerPos.position);

        if(distance > 5f) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
        if(health <= 0) {
            Death(gameObject);
        }
    }
}
