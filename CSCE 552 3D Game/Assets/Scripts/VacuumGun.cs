using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumGun : MonoBehaviour
{
    public float bulletSpeed = 10;
    public GameObject bullet;
    public Rigidbody rb;
    public Transform bulletSpawn;
    public int redBullets;
    public int greenBullets;
    public int blueBullets;

    public int activeBullet = 0;
    private int tempValue;
    List<int> bulletList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {  
        //Assignes all of the values for starting ammo 
        bulletList.Add(redBullets);
        bulletList.Add(greenBullets);
        bulletList.Add(blueBullets);

        //Displays to console starting ammo
        for(int i = 0; i < bulletList.Count; i++) {
            Debug.Log(i + " is " + bulletList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Fire active bullet
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject clone;
            clone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            rb.velocity = new Vector3(10 * Time.deltaTime, 0, 0);
            decreaseBullet();
        }

        //Cycle bullets forwards
        if(Input.GetKeyDown(KeyCode.E)) {
            if(activeBullet < 2) {
                activeBullet++;
            }
            else {
                activeBullet = 0;
            }
            notifyBullet();
        }
        //Cycle bullets backwards
        if(Input.GetKeyDown(KeyCode.Q)) {
            if(activeBullet > 0) {
                activeBullet--;
            }
            else {
                activeBullet = 2;
            }
            notifyBullet();
        }
    }
    
    //Notifys the user which bullet is active on the console
    void notifyBullet() {
        switch(activeBullet){
            case 0:
            Debug.Log("Red Bullets now active");
            break;
            case 1:
            Debug.Log("Green Bullets now active");
            break;
            case 2:
            Debug.Log("Blue Bullets now active");
            break;
        }
    }
    void decreaseBullet() {
        if(bulletList[activeBullet] > 0) {
            tempValue = bulletList[activeBullet];
            tempValue--;
            if(activeBullet == 0) {
                redBullets = tempValue;
            }
            else if(activeBullet == 1) {
                greenBullets = tempValue;
            }
            else {
                blueBullets = tempValue;
            }
            bulletList[activeBullet] = tempValue;
        }
        else {
            Debug.Log("Out of ammo...");
        }
    }
}
