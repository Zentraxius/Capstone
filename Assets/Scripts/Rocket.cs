using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody; // Type is Rigibody, name is rigidBody
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Booster();
        Rotate(); 
    }


    private void Booster()
    {
        if (Input.GetKey(KeyCode.Space))
        { // Can use booster while turning
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            print("Boost-SPACE is currently being deployed");
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true; // Essentially disabled physics interaction while using thrusters 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
            print("A is being registered");
        }
        else if (Input.GetKey(KeyCode.D)) // Cannot use both A and D simultaneously
        {
            transform.Rotate(-Vector3.forward);
            print("D is being registered");
        }
        rigidBody.freezeRotation = false; // Re-enables physics
    }
}
