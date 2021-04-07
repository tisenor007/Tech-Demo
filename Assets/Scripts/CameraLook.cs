using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform cameraPos;
    public Transform playerbody;
    public float smoothSpeed = 0.125f;
    
    public float mouseSensitivity = 100f;
    public float xRotation = 0f;
    public float YRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = cameraPos.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //transform.LookAt(playerbody);
    }
    // Update is called once per frame
    void Update()
    {

        //float mouseX += Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        xRotation += -Input.GetAxis("Mouse Y") * mouseSensitivity;
        YRotation += Input.GetAxis("Mouse X") * mouseSensitivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);


        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.localRotation = Quaternion.Euler(0, YRotation, 0);
        playerbody.transform.localRotation = Quaternion.Euler(0, YRotation, 0);
        //cameraPos.transform.localRotation = Quaternion.Euler(0, YRotation, 0);
        //if (Input.GetKeyDown(KeyCode.Escape))
    }
}
