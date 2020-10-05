using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody; // Type is Rigibody, name is rigidBody
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float rcsRotate = 250f;

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
        float thrustThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        { // Can use booster while turning
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
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
        // float rcsThrust = 250f;
        float rotationThisFrame = rcsRotate * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
            print("A is being registered");
        }
        else if (Input.GetKey(KeyCode.D)) // Cannot use both A and D simultaneously
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            print("D is being registered");
        }
        rigidBody.freezeRotation = false; // Re-enables physics
    }
}
