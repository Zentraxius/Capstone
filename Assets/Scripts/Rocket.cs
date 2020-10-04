using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody; // Type is Rigibody, name is rigidBody

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput(); 
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        { // Can use booster while turning
            rigidBody.AddRelativeForce(Vector3.up);

        }
        ///
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) // Cannot use both A and D simultaneously
        {
            transform.Rotate(-Vector3.forward);
        }
        ///
    }
}
