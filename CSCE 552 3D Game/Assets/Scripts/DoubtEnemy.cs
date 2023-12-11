using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubtEnemy : EnemyOne
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float doubtAttackTimer;
    public float doubtRangeTimer;
    void Update() {
        transform.LookAt(playerPos);
        float distance = Vector3.Distance(transform.position, playerPos.position);
        doubtAttackTimer += Time.deltaTime;
        doubtRangeTimer += Time.deltaTime;

        if(distance > 5f) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(distance <= 10f) {
            if(doubtRangeTimer >= 3f){
                GameObject clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                doubtRangeTimer = 0f;
            }
        }
        if(distance <= 5f) {
            if(doubtAttackTimer >= 1f){
                GameManager.health -= 10;
                doubtAttackTimer = 0f;
            }
        }
        
        if(health <= 0) {
            Death(gameObject);
        }
    }
}
