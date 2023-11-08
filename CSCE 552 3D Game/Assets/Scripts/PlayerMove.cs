using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public int health = 100;
    public float distToGround = 0.3f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    bool isGrounded;

    Vector3 velocity;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K)) {
            Debug.Log("Save ran");
            SavePlayer();
        }
        if(Input.GetKey(KeyCode.L)) {
            Debug.Log("Load Ran");
            LoadPlayer();
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, distToGround, groundMask);
        
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    public void SavePlayer() {
        GameSave.SavePlayer(this);
    }
    public void LoadPlayer() {
        PlayerData data = GameSave.LoadPlayer();

        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
