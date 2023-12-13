using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearEnemy : EnemyOne
{
    Animator animator;
    public Transform bulletSpawn;
    public GameObject bullet;
    public AudioSource attackSound;
    private float timer;

    void Update() {
        animator = GetComponent<Animator>();
        timer += Time.deltaTime;

        transform.LookAt(playerPos);
        float distance = Vector3.Distance(transform.position, playerPos.position);
        transform.LookAt(playerPos);
        if(distance > 15f) {
            animator.SetBool("inRange", false);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(distance < 15f) {
            animator.SetBool("inRange", true);
            if(timer >= 2.0f){
                GameObject clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                attackSound.Play();
                timer = 0f;
            }
            //transform.position += transform.forward * -1 * speed * Time.deltaTime;
        }
        if(health <= 0) {
            Death(gameObject);
        }
    }
}
