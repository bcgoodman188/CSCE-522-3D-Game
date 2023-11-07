using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiHandler : MonoBehaviour
{
    public GameObject redBulletSprite;
    public GameObject greenBulletSprite;
    public GameObject blueBulletSprite;
    public TextMeshProUGUI redBulletText;
    public TextMeshProUGUI greenBulletText;
    public TextMeshProUGUI blueBulletText;

    private Vector3 scaleChange;
    private Vector3 initScale;

    void Start() {
        initScale = blueBulletSprite.transform.localScale;
        scaleChange = new Vector3(1.5f, 1.5f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        //Updates the ammout of each ammo the player has
        redBulletText.text = VacuumGun.redBullets.ToString();
        greenBulletText.text = VacuumGun.greenBullets.ToString();
        blueBulletText.text = VacuumGun.blueBullets.ToString();

        //Adjusts the UI size of the ammo counters
        switch(VacuumGun.activeBullet) {
            case 0:
                greenBulletSprite.transform.localScale = initScale;
                blueBulletSprite.transform.localScale = initScale;
                redBulletSprite.transform.localScale = scaleChange;
                break;
            case 1:
                redBulletSprite.transform.localScale = initScale;
                blueBulletSprite.transform.localScale = initScale;
                greenBulletSprite.transform.localScale = scaleChange;
                break;
            case 2:
                redBulletSprite.transform.localScale = initScale;
                greenBulletSprite.transform.localScale = initScale;
                blueBulletSprite.transform.localScale = scaleChange;
                break;
        }
    }

}
