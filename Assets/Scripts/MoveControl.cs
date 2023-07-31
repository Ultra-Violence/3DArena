using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Joystick joystickLook;
    public Joystick joystickMove;
    public GameObject camera;

    public float moveSpeed;

    float moveCameraVertical;
    float moveCameraHorizontal;

    float movePlayerVertical;
    float movePlayerHorizontal;

    public float yRotation;
    private float xRotation;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        moveCameraVertical = joystickLook.Vertical * 70 * Time.fixedDeltaTime;
        moveCameraHorizontal = joystickLook.Horizontal * 70 * Time.fixedDeltaTime;

        yRotation += moveCameraHorizontal;
        xRotation -= moveCameraVertical;
        xRotation = Mathf.Clamp(xRotation, -90f, 30f);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        camera.GetComponent<Transform>().rotation = Quaternion.Euler(xRotation, yRotation , 0);


        movePlayerVertical = joystickMove.Vertical;
        movePlayerHorizontal = joystickMove.Horizontal;

        Vector3 movement = new Vector3(movePlayerHorizontal, 0, movePlayerVertical);
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
