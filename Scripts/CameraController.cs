using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform follow;

    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private Vector3 rotate = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Rotate();
    }
    private void HandleInput()
    {
        rotate.y = Input.GetAxis("Mouse X");
        //rotate.x = Input.GetAxis("Mouse Y");
    }
    private void Rotate()
    {
        transform.Rotate(rotate * rotateSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        transform.position = follow.position;
    }
}
