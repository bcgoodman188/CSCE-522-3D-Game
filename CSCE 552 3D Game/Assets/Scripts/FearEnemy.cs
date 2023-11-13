using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearEnemy : EnemyOne
{
    public Transform bulletSpawn;
    public GameObject bullet;
    private float timer;

    void Update() {
        timer += Time.deltaTime;
        if(timer >= 3.0f){
            GameObject clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            timer = 0f;
        }

        transform.LookAt(playerPos);
        float distance = Vector3.Distance(transform.position, playerPos.position);
        transform.LookAt(playerPos);
        if(distance > 5f) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(distance < 5f) {
            transform.position += transform.forward * -1 * speed * Time.deltaTime;
        }
        if(health <= 0) {
            Death(gameObject);
        }
    }
}
