using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float currentVelocity;
    [SerializeField] private bool activeInput;

    [Header("Movement")]
    [SerializeField] private float accelerationForce = 5f;
    [SerializeField] private float maxMovementSpeed = 10f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] public Vector3 camForward = Vector3.zero;
    [SerializeField] public Vector3 camRight = Vector3.zero;


    private GroundedChecker checker;
    private Rigidbody rigidBody;
    [SerializeField] public Vector3 moveDirection = Vector3.zero;
    
    public float MaxMovementSpeed
    { 
        get { return maxMovementSpeed; }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        checker = GetComponentInChildren<GroundedChecker>();
    }

    void Update()
    {
        HandleInput();
        if(Input.GetKey(KeyCode.JoystickButton4))
        {
            Vector3 newOrientation= new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
            rigidBody.MoveRotation(Quaternion.Euler(newOrientation));
        }
        else if (activeInput)
        {
            Quaternion rotationMission = Quaternion.RotateTowards(rigidBody.rotation, Quaternion.LookRotation(moveDirection), 3);
            rigidBody.MoveRotation(rotationMission);
        }   
        
        currentVelocity = rigidBody.velocity.magnitude;
    }

    private void HandleInput()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        activeInput = horInput != 0 || verInput != 0;

        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;
        moveDirection = forwardRelative + rightRelative;

    }

    private void FixedUpdate()
    {
        MoveCharacter();
        if(Input.GetKey(KeyCode.JoystickButton0) && checker.InContact)
        {
            Jump();
        }
        RestrictTerminalVelocity();
    }

    private void MoveCharacter()
    {
        Vector3 force = moveDirection * accelerationForce;
        rigidBody.AddForce(force, ForceMode.Force);
    }
    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void RestrictTerminalVelocity()
    {
        if (rigidBody.velocity.magnitude > maxMovementSpeed)
        {
            Vector3 normalizedVelocity = rigidBody.velocity.normalized;

            Vector3 newVelocity = new Vector3(
                    normalizedVelocity.x * maxMovementSpeed,
                    rigidBody.velocity.y,
                    normalizedVelocity.z * maxMovementSpeed
            );

            rigidBody.velocity = newVelocity;
        }
    }
}
