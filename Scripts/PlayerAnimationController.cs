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

        if(Input.GetKey(KeyCode.JoystickButton4))
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
