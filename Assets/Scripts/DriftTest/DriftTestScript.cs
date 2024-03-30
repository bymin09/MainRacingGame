using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftTestScript : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    public float kmh;
    public ForceMode force;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private Quaternion FLWTransformPos;
    private Quaternion FRWTransformPos;
    // float SpeedQue = 10.0f;

    private void Update()
    {
        //WheelReset();
    }

    private void FixedUpdate()
    {
        // SetWheelsPos();
        GetInput();
        HandleMotor();
        HandleSteering();
        //UpdateWheels();
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    void WheelReset()
    {
        frontLeftWheelTransform.transform.position = frontLeftWheelCollider.transform.position;
        frontRightWheelTransform.transform.position = frontRightWheelCollider.transform.position;
        rearLeftWheelTransform.transform.position = rearLeftWheelCollider.transform.position;
        rearRightWheelTransform.transform.position = rearRightWheelCollider.transform.position;
    }

    //private void UpdateWheels()
    //{

    //    UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
    //    UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
    //    UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    //    UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    //}

    //private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    //{
    //    Vector3 pos;
    //    Quaternion rot;
    //    wheelCollider.GetWorldPose(out pos, out rot);
    //    wheelTransform.rotation = rot;
    //    wheelTransform.position = pos;
    //}

    //public void SetWheelsPos()
    //{
    //    SetWheelsRot(frontLeftWheelTransform);
    //    SetWheelsRot(frontRightWheelTransform);
    //    SetWheelsRot(rearLeftWheelTransform);
    //    SetWheelsRot(rearRightWheelTransform);
    //}
    //public void SetWheelsRot(Transform wheelTransform)
    //{
    //    FLWTransformPos = wheelTransform.transform.rotation;
    //    FRWTransformPos = wheelTransform.transform.rotation;
        
    //}
}
