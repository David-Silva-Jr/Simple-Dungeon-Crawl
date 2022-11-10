using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour, IActor
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float hp;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private string actorName;

    [SerializeField]
    private float jumpHeight;

    private Vector3 localMoveVector;
    private Vector3 worldMoveVector;

    private Vector3 playerVelocity;

    public float MoveSpeed {
        get {return moveSpeed;}
        set {moveSpeed = value;}
    }

    public float TurnSpeed {
        get {return turnSpeed;}
        set {turnSpeed = value;}
    }

    public float Hp {
        get {return hp;}
        set {hp = value;}
    }

    public float MaxHp {
        get {return maxHp;}
        set {maxHp = value;}
    }

    public string ActorName {
        get {return actorName;}
        set {actorName = value;}
    }

    public CharacterController controller;
    public Camera Camera;

    void Start(){
        localMoveVector = new Vector3();
        worldMoveVector = new Vector3();
        playerVelocity = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float velocityDot = Vector3.Dot(playerVelocity, Physics.gravity);
        if (controller.isGrounded && velocityDot > 0)
        {
            playerVelocity =  -Physics.gravity * Time.deltaTime;
        }

        localMoveVector = new Vector3(xInput, 0, yInput);
        if(localMoveVector.sqrMagnitude > 1){
            localMoveVector.Normalize();
        }

        Vector3 localCameraLook = transform.worldToLocalMatrix * Camera.transform.forward;
        float lookDifference = Vector2.SignedAngle(new Vector2(localCameraLook.x, localCameraLook.z), new Vector2(0, 1));
        transform.RotateAround(transform.position, transform.up, turnSpeed * Mathf.Sign(lookDifference) * localMoveVector.sqrMagnitude * Time.deltaTime);

        worldMoveVector = transform.localToWorldMatrix * localMoveVector;   

        // Changes the height position of the player..
        if (controller.isGrounded && Input.GetMouseButtonDown(0))
        {
            playerVelocity -= Mathf.Sqrt(jumpHeight * Physics.gravity.magnitude * 2f) * Physics.gravity.normalized;
            print("Jump");
        }     

        playerVelocity += Physics.gravity * Time.deltaTime;
        controller.Move((playerVelocity + (worldMoveVector * moveSpeed)) * Time.deltaTime);
    }
}
