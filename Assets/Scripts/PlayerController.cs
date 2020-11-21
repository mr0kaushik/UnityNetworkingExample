using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float m_Speed = 5f;

    [SerializeField]
    private float m_CameraSenstivity = 5f;
    private PlayerMotor m_Motor;

    void Start()
    {
        m_Motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xAxisMovement = Input.GetAxisRaw("Horizontal");
        float _zAxisMovement = Input.GetAxisRaw("Vertical");

        // Horizontal & Vertical Movement
        Vector3 _movHorizontal = transform.right * _xAxisMovement;
        Vector3 _movVertical = transform.forward * _zAxisMovement;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * m_Speed;

        // Move Object
        m_Motor.Move(_velocity);


        // Cacluate Rotation
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, _yRotation, 0f) * m_CameraSenstivity;
        m_Motor.Rotate(rotation);

        
        // Cacluate Rotation for Camera
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 rotationCamera = new Vector3(_xRotation, 0f, 0f) * m_CameraSenstivity;
        m_Motor.RotateCamera(rotationCamera);

    }
}
