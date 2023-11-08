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
        if(health <= 0){
            Destroy(gameObject);
            Instantiate(bulletDrop, gameObject.transform.position + offset, gameObject.transform.rotation);
            Instantiate(bulletDrop2, gameObject.transform.position, gameObject.transform.rotation);
            GameManager.score += pointValue;
        }
        if(playerPos == null) {
            return;
        }
        transform.LookAt(playerPos);

        float distance = Vector3.Distance(transform.position, playerPos.position);

	if(distance > 1f)	
		transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == lethalBullet) {
            Destroy(col.gameObject);
            Debug.Log("I ran");
            health = health - 3;
        }
    }
}
