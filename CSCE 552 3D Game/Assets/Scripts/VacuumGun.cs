using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumGun : MonoBehaviour
{
    public static bool isLoaded = false;
    public Camera playerCamera;
    public float bulletSpeed = 10;
    public int pointsForAbsorb;
    public static bool canFire = true;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public GameObject greenBulletPrefab;
    public Rigidbody rb;
    public Transform bulletSpawn;
    public static int redBullets;
    public int savedRed;
    public static int greenBullets;
    public int savedGreen;
    public static int blueBullets;
    public int savedBlue;

    public static int activeBullet = 0;
    public int saveActive;
    private int tempValue;
    List<int> bulletList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {  
    if(isLoaded == false) {
        //gunData = gameObject.GetComponent<>();
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
    else {
        LoadGun();
        bulletList.Add(redBullets);
        bulletList.Add(greenBullets);
        bulletList.Add(blueBullets);
        isLoaded = false;
    } 
    }

    // Update is called once per frame
    void Update()
    {
        bulletList[0] = redBullets;
        bulletList[1] = greenBullets;
        bulletList[2] = blueBullets;

        //Saves amount of bullets in non-static int to be saved.
        saveActive = activeBullet;
        savedRed = bulletList[0];
        savedGreen = bulletList[1];
        savedBlue = bulletList[2];

        //Fire active bullet
        if(Input.GetKeyDown(KeyCode.Mouse0) && canFire == true) {
            if(bulletList[activeBullet] > 0) {
                Fire();
                decreaseBullet();
            }
            else { 
                Debug.Log("Out of ammo");
            }
        }
        //Absorbs Bullets
        if(Input.GetKey(KeyCode.Mouse1)) {
            canFire = false;
            Absorb();
        }
        if(Input.GetKeyUp(KeyCode.Mouse1)) {
            canFire = true;
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
            if(hit.collider.CompareTag("RedAmmo")) {
                Debug.Log("Yup, it's a RED bullet");
                Destroy(hit.collider.gameObject);
                redBullets++;
                //bulletList[0]++;
                GameManager.score += pointsForAbsorb;
            }
            else if(hit.collider.CompareTag("GreenAmmo")) {
                Debug.Log("Yup, it's a GREEN bullet");
                Destroy(hit.collider.gameObject);
                greenBullets++;
                //bulletList[1]++;
                GameManager.score += pointsForAbsorb;
            }
            else if(hit.collider.CompareTag("BlueAmmo")) {
                Debug.Log("Yup, it's a BLUE bullet");
                Destroy(hit.collider.gameObject);
                blueBullets++;
                //bulletList[2]++;
                GameManager.score += pointsForAbsorb;
            }
        }
        else {
            target = raycast.GetPoint(75);
            Debug.Log("MISS");
        }

        Vector3 distance = target - bulletSpawn.position;
    }
    public void SaveGun() {
        GameSave.SaveGun(this);
    }
    public void LoadGun() {
        VacuumData gunData = GameSave.LoadGun();

        activeBullet = gunData.active;

        redBullets = gunData.bullets[0];
        greenBullets = gunData.bullets[1];
        blueBullets = gunData.bullets[2];
    }
}
