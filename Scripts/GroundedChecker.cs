using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{

    private int contactNo;

    public bool InContact
    {
        get { return (contactNo > 0); }
    }
    // Start is called before the first frame update
    void Start()
    {
        contactNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        contactNo += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        contactNo -= 1;
    }
}
