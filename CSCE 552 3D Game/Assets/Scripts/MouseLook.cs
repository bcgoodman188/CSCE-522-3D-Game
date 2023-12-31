using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
   
    public Transform body;

    float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    
        xRotate -= mY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        body.Rotate(Vector3.up * mX);
    }
}
