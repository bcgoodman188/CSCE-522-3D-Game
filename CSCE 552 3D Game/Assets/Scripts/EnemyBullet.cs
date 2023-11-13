using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody bulletRb;
    public float bulletSpeed;
    
    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Player")) {
            //PlayerMove pm = gameObject.GetComponent<PlayerMove>();
            GameManager.health -= 10;
            Destroy(gameObject);
        }
    }
}
