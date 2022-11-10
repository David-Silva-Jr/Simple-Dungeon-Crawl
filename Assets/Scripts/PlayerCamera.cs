using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float distance;
    public float lookSpeed;
    public float lerpConstant;
    public Vector3 targetOffset;
    public Transform player;
    public Transform cameraHelper;
    public Vector3 targetCameraHelperPosition;

    void Start(){
        targetCameraHelperPosition = player.TransformPoint(targetOffset);
        cameraHelper.rotation = player.rotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        float horizontalAngle = lookSpeed * Time.deltaTime * mouseX;
        float verticalAngle = lookSpeed * Time.deltaTime * mouseY;

        targetCameraHelperPosition = Quaternion.AngleAxis(horizontalAngle, player.up) * targetCameraHelperPosition;
        
        cameraHelper.position = player.position + targetCameraHelperPosition;
        cameraHelper.RotateAround(cameraHelper.position, player.up, horizontalAngle);

        Quaternion temp = cameraHelper.rotation;
        cameraHelper.rotation = Quaternion.AngleAxis(verticalAngle, cameraHelper.right) * cameraHelper.rotation;
        if(Vector3.Angle(player.up, cameraHelper.up) > 80){
            cameraHelper.rotation = temp;
        }

        transform.position = Vector3.Lerp(transform.position, cameraHelper.position - (cameraHelper.forward * distance), lerpConstant * Time.deltaTime);
        transform.LookAt(cameraHelper, player.up);
    }

    void FixedUpdate(){

        
    }
}
