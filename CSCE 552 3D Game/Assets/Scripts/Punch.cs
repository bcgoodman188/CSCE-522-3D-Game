using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject fist;
    public float cooldown;
    private float timer;
    void Start() {
        timer = cooldown;
    }
    void Update() {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.F) && timer > cooldown) {
            timer = 0.0f;
            moveArmUp();
        }
        if(timer > 0.25f) {
            moveArmDown();
        }
    }
    void moveArmUp() {
        fist.SetActive(true);
    }
    void moveArmDown() {
        fist.SetActive(false);
    }
}
