using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform playerPos;
    public Rigidbody bulletRb;
    public AudioSource takeDamage;
    public float bulletSpeed;
    Vector3 direction;
    
    void Start() {
        if(playerPos == null) {
            if(GameObject.FindWithTag("Player") != null) {
                playerPos = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }
        direction = playerPos.transform.position - this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = direction.normalized * bulletSpeed;//transform.forward * bulletSpeed;
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Player")) {
            //PlayerMove pm = gameObject.GetComponent<PlayerMove>();
            GameManager.health -= 10;
            takeDamage.Play();
            Destroy(gameObject,0.2f);
        }
    }
}
