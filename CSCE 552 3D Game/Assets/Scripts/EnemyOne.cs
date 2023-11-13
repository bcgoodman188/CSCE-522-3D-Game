using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int pointValue;
    public int health = 6;
    public string lethalBullet;
    public Transform playerPos;
    public float speed;
    public GameObject bulletDrop;
    public GameObject bulletDrop2;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1f, 0f, 0);
        if(playerPos == null) {
            if(GameObject.FindWithTag("Player") != null) {
                playerPos = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(health <= 0){
            Instantiate(bulletDrop, gameObject.transform.position + offset, gameObject.transform.rotation);
            Instantiate(bulletDrop2, gameObject.transform.position, gameObject.transform.rotation);
            GameManager.score += pointValue;
        }
        */
        if(playerPos == null) {
            return;
        }
    }

    void OnTriggerEnter(Collider col) { 
        if(col.gameObject.tag == lethalBullet) {
            Destroy(col.gameObject);
            Debug.Log("I ran");
            health = health - 3;
        }
    }
    public void Death(GameObject gameObject) {
        Destroy(gameObject);
        Instantiate(bulletDrop, gameObject.transform.position + offset, gameObject.transform.rotation);
        Instantiate(bulletDrop2, gameObject.transform.position, gameObject.transform.rotation);
        GameManager.score += pointValue;
    }
}
