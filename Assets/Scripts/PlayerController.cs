using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float ThrustForce = 1000f;
    public float RotationForce = 50f;
    [Header("Cached References")]
    public Rigidbody myRigibody = null;

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            myRigibody.AddRelativeForce(Vector3.up * ThrustForce * Time.deltaTime);
        }
        else
        {

        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(1.0f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-1.0f);
        }
    }

    public void ApplyRotation(float aRotationDirection)
    {
        myRigibody.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationForce * Time.deltaTime * aRotationDirection);
    }
}
