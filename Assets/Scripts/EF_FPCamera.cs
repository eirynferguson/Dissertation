using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_FPCamera : MonoBehaviour
{
    private GameObject target;

    public Transform player;
    public float mouseSensitivity = 2.0f;
    float camVerticleRot = 0f;

    //bool lockCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        //Lock Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void FixedUpdate()
    {
        //Moves Camera with Player
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 0.8f, target.transform.position.z);

        //Mouse Input
        float inputX = Input.GetAxis("Mouse X")*mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y")*mouseSensitivity;

        //Rotate Camera x axis

        camVerticleRot -= inputY;
        camVerticleRot = Mathf.Clamp(camVerticleRot, -90f, 90f);
        transform.localEulerAngles = Vector3.right * camVerticleRot;

        //Rotate Player and Camera y axis

        player.Rotate(Vector3.up * inputX);
    }
}
