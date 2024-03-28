using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class CarController : MonoBehaviour
    {
        public WheelCollider[] wheels = new WheelCollider[4];
        public GameObject[] wheelMesh = new GameObject[4];
        // 엔진이 내는 순간적인 힘
        // 단위 kgm * m => 1m의 줄에 중량 1kg의
        // 물체를 달아 호전시키는 힘

        public float maxToque = 30;
        public float steeringMax = 4;
        public float angle = 0;
        public float kmh;
        public GameData gameData;
        public GameObject detination;
        public float minDistance = 5.0f;
        public Transform CenterOfMess;

        // -Test Drift-
        public WheelCollider rearWheelLeft = new WheelCollider();
        public WheelCollider rearWheelRight = new WheelCollider();

        WheelCollider RWLCollider;
        WheelCollider RWRCollider;

        // 뒷 바퀴 마찰
        WheelFrictionCurve fFrictionRWL;
        WheelFrictionCurve sFrictionRWL;
        WheelFrictionCurve fFrictionRWR;
        WheelFrictionCurve sFrictionRWR;

        float slipRate = 1.0f; // 타이어 마찰계수 마다 마찰력이 달리짐
        float handBreakSlipRate = 0.4f; // 타이어 마찰계수
         
        // -----------
        
        private void Start()
        {
            this.GetComponent<Rigidbody>().centerOfMass = CenterOfMess.localPosition;

            // -Test Drift-

            RWLCollider = rearWheelLeft.GetComponent<WheelCollider>();
            RWRCollider = rearWheelRight.GetComponent<WheelCollider>();

            // 타이어 마찰
            fFrictionRWL = RWLCollider.forwardFriction;
            sFrictionRWL = RWLCollider.sidewaysFriction;
            fFrictionRWR = RWRCollider.forwardFriction;
            sFrictionRWR = RWRCollider.sidewaysFriction;

            // -----------
        }

        void TestDrift()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                fFrictionRWL.stiffness = handBreakSlipRate;
                RWLCollider.forwardFriction = fFrictionRWL;

                sFrictionRWL.stiffness = handBreakSlipRate;
                RWLCollider.forwardFriction = sFrictionRWL;

                fFrictionRWR.stiffness = handBreakSlipRate;
                RWRCollider.forwardFriction = fFrictionRWR;

                sFrictionRWR.stiffness = handBreakSlipRate;
                RWRCollider.forwardFriction = sFrictionRWR;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                // 마찰 복원

                fFrictionRWL.stiffness = slipRate;
                RWLCollider.forwardFriction = fFrictionRWL;

                sFrictionRWL.stiffness = slipRate;
                RWLCollider.forwardFriction = sFrictionRWL;

                fFrictionRWR.stiffness = slipRate;
                RWRCollider.forwardFriction = fFrictionRWR;

                sFrictionRWR.stiffness = slipRate;
                RWRCollider.forwardFriction = sFrictionRWR;
            }
        }

        void FixedUpdate()
        {
            PlayToque();
            TestDrift();
        }

        void PlayToque()
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = maxToque * Input.GetAxis("Vertical");
                }
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                for (int i = 0; i < wheels.Length - 2; i++)
                {
                    wheels[i].steerAngle = maxToque * Input.GetAxis("Horizontal");
                }
            }
            else
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].steerAngle = 0f;
                }
            }

        }
    }
}

