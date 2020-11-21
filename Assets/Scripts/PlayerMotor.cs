using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    [SerializeField]
    private Camera m_Camera;

    private Vector3 m_Velocity = Vector3.zero;
    private Vector3 m_Rotation = Vector3.zero;
    private Vector3 m_CameraRotation = Vector3.zero;



    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 velocity)
    {
        m_Velocity = velocity;
    }


    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if (m_Velocity != Vector3.zero)
        {
            rigidBody.MovePosition(rigidBody.position + m_Velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        rigidBody.MoveRotation(rigidBody.rotation * Quaternion.Euler(m_Rotation));
        if (m_Camera != null)
        {
            m_Camera.transform.Rotate(-m_CameraRotation);
        }
    }

    public void Rotate(Vector3 rotation)
    {
        m_Rotation = rotation;
    }
    public void RotateCamera(Vector3 rotation)
    {
        m_CameraRotation = rotation;
    }
}
