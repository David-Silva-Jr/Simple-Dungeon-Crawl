using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody projectile;
    public Camera cam;
    public Transform player;

    public ForceMode mode = ForceMode.VelocityChange;
    public float launchSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 projectileStartPos = player.position + cam.transform.forward * 2;
        if(Input.GetMouseButtonUp(1)){
            Rigidbody launched = Instantiate<Rigidbody>(projectile);
            launched.position = projectileStartPos;
            launched.AddForce(cam.transform.forward * launchSpeed, mode);
        }
    }
}
