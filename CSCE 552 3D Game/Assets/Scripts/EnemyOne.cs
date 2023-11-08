using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public Transform playerPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if(playerPos == null) {
            if(GameObject.FindWithTag("Player") != null) {
                playerPos = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos == null) {
            return;
        }
        transform.LookAt(playerPos);

        float distance = Vector3.Distance(transform.position, playerPos.position);

	if(distance > 1f)	
		transform.position += transform.forward * speed * Time.deltaTime;
    }
}
