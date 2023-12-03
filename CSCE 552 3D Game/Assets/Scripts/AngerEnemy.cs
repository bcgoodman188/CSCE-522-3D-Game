using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerEnemy : EnemyOne
{
    public float attackTimer;
    void Update() {
        Vector3 myLook = new Vector3(playerPos.position.x, gameObject.transform.position.y, playerPos.position.z);
        this.gameObject.transform.LookAt(myLook);
        attackTimer += Time.deltaTime;

        transform.LookAt(playerPos);
        float distance = Vector3.Distance(transform.position, playerPos.position);
        transform.LookAt(playerPos);
        if(distance > 3f) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(distance <= 3f) {
            if(attackTimer >= 1.5f) {
                GameManager.health -= 10;
                attackTimer = 0f;
            }
        }
        if(health <= 0) {
            Death(gameObject);
        }
    }
}
