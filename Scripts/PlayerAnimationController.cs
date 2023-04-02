using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();   
    }

    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        bool isStrafing = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E);
        if (isStrafing)
        {
            animator.SetFloat("VelocityX", horInput*2);
            animator.SetFloat("VelocityZ", verInput*2);
        }
        else
        {
            float maxInput = Mathf.Abs(horInput) + Mathf.Abs(verInput);
            animator.SetFloat("VelocityZ", maxInput);
            animator.SetFloat("VelocityX", 0f);

        }

    }
}
