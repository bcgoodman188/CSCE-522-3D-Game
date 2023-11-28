using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroy : MonoBehaviour
{
    public AudioSource crateBreak;
    public GameObject bulletDrop;
    public GameObject bulletDrop2;
    public GameObject bulletDrop3;
    public Vector3 offset;
    public Vector3 offset2;

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Arm")) {
            crateBreak.Play();
            for(int i = 0; i < 5; i++) {
                Instantiate(bulletDrop, gameObject.transform.position + offset, gameObject.transform.rotation);
                Instantiate(bulletDrop2, gameObject.transform.position, gameObject.transform.rotation);
                Instantiate(bulletDrop3, gameObject.transform.position + offset2, gameObject.transform.rotation);
            }
            Destroy(gameObject, 0.5f);
        }
    }
}
