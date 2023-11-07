using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumGun : MonoBehaviour
{
    public Camera playerCamera;
    public float bulletSpeed = 10;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public GameObject greenBulletPrefab;
    public Rigidbody rb;
    public Transform bulletSpawn;
    public static int redBullets;
    public static int greenBullets;
    public static int blueBullets;

    public static int activeBullet = 0;
    private int tempValue;
    List<int> bulletList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {  
        redBullets = 5;
        greenBullets = 5;
        blueBullets = 5;
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
            if(bulletList[activeBullet] > 0) {
                Fire();
                decreaseBullet();
            }
            else { 
                Debug.Log("Out of ammo");
            }
        }
        //Absorbs Bullets
        if(Input.GetKeyDown(KeyCode.Mouse1)) {
            Absorb();
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
    void Fire() {
        Ray raycast = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 target;
        if (Physics.Raycast(raycast, out hit)) {
            target = hit.point;
        }
        else {
            target = raycast.GetPoint(75);
        }

        Vector3 distance = target - bulletSpawn.position;

        if(activeBullet == 0) {
            GameObject newRedBullet = Instantiate(redBulletPrefab, bulletSpawn.position, Quaternion.identity);
            newRedBullet.transform.forward = distance.normalized;
            //Force used to move bullet forward
            newRedBullet.GetComponent<Rigidbody>().AddForce(distance.normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(newRedBullet, 4f);
        }
        else if(activeBullet == 1) {
            GameObject newGreenBullet = Instantiate(greenBulletPrefab, bulletSpawn.position, Quaternion.identity);
            newGreenBullet.transform.forward = distance.normalized;
            //Force used to move bullet forward
            newGreenBullet.GetComponent<Rigidbody>().AddForce(distance.normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(newGreenBullet, 4f);
        }
        else if(activeBullet == 2) {
            GameObject newBlueBullet = Instantiate(blueBulletPrefab, bulletSpawn.position, Quaternion.identity);
            newBlueBullet.transform.forward = distance.normalized;
            //Force used to move bullet forward
            newBlueBullet.GetComponent<Rigidbody>().AddForce(distance.normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(newBlueBullet, 4f);
        }
    }
    void Absorb() {
        Ray raycast = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 target;
        if (Physics.Raycast(raycast, out hit)) {
            Debug.Log("HIT");
            target = hit.point;
        }
        else {
            target = raycast.GetPoint(75);
            Debug.Log("MISS");
        }

        Vector3 distance = target - bulletSpawn.position;
    }
}
