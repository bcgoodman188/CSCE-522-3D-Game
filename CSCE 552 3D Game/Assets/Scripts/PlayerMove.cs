using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static bool isLoaded = false;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float distToGround = 0.3f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    bool isGrounded;

    Vector3 velocity;
    
    void Start() {
        if(isLoaded == true) {
            LoadPlayer();
            isLoaded = false;
        }
    }
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.K)) {
            Debug.Log("Save Ran");
            SavePlayer();
        }
        if(Input.GetKey(KeyCode.L)) {
            Debug.Log("Load Ran");
            LoadPlayer();
        }
        */
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
        //Debug.Log(transform.position);
    }
    public void LoadPlayer() {
        PlayerData data = GameSave.LoadPlayer();

        Vector3 position;
        position.x = data.pos[0];
        position.y = data.pos[1];
        position.z = data.pos[2];

        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
        Debug.Log(transform.position);
    }
}
