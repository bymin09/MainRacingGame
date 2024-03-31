using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class DriftTestScript : MonoBehaviour
    {
        private float horizontalInput, verticalInput;
        private float currentSteerAngle, currentbreakForce;
        private bool isBreaking;
        public float kmh;
        public ForceMode force;
        public GameData gameData;

        public GameObject OriginTire;
        public GameObject DesertTire;
        public GameObject ForestTire;
        public GameObject CityTire;
        int TireModel = 0;

        // Settings
        [SerializeField] private float motorForce, breakForce, maxSteerAngle;
        float speed;

        // Wheel Colliders
        [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
        [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

        // Wheels
        [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
        [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

        private Quaternion FLWTransformPos;
        private Quaternion FRWTransformPos;
        // float SpeedQue = 10.0f;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        private void Update()
        {
            //WheelReset();
        }

        private void FixedUpdate()
        {
            SetCar();
            kmh = Mathf.Round(this.GetComponent<Rigidbody>().velocity.magnitude * 3.6f);
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

        public void SetCar()
        {
            TireModel = gameData.tireNum;

            switch (TireModel)
            {
                case 0:
                    OriginTire.gameObject.SetActive(true);
                    DesertTire.gameObject.SetActive(false);
                    ForestTire.gameObject.SetActive(false);
                    CityTire.gameObject.SetActive(false);
                    break;
                case 1:
                    OriginTire.gameObject.SetActive(false);
                    DesertTire.gameObject.SetActive(true);
                    ForestTire.gameObject.SetActive(false);
                    CityTire.gameObject.SetActive(false);
                    break;
                case 2:
                    OriginTire.gameObject.SetActive(false);
                    DesertTire.gameObject.SetActive(false);
                    ForestTire.gameObject.SetActive(true);
                    CityTire.gameObject.SetActive(false);
                    break;
                case 3:
                    OriginTire.gameObject.SetActive(false);
                    DesertTire.gameObject.SetActive(false);
                    ForestTire.gameObject.SetActive(false);
                    CityTire.gameObject.SetActive(true);
                    break;
            }

            if (gameData != null)
            {
                switch (gameData.engineNum)
                {
                    case 0: // 기본
                        break;
                    case 1: //  터보
                        motorForce += 500;
                        break;
                    case 2:
                        motorForce += 1000;
                        break;
                }

                if (gameData.stageNum - 1 == TireModel)
                {
                    motorForce += 1000;
                }
            }

        }

        //void WheelReset()
        //{
        //    frontLeftWheelTransform.transform.position = frontLeftWheelCollider.transform.position;
        //    frontRightWheelTransform.transform.position = frontRightWheelCollider.transform.position;
        //    rearLeftWheelTransform.transform.position = rearLeftWheelCollider.transform.position;
        //    rearRightWheelTransform.transform.position = rearRightWheelCollider.transform.position;
        //}

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
}
