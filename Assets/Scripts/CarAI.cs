using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class CarAI : MonoBehaviour
    {
        public WayPointNode waypointNode;
        public List<Transform> nodes = new List<Transform>();
        public Transform currentWayPoint;
        public int currentNum = 0;
        
        [Range(0, 10)]
        public float steerForce;
        public float minDistance = 5.0f;

        public float vertical = 3.0f;
        public float horizontal;

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
        public Transform CenterOfMess;

        void Start()
        {
            for (int i = 0; i < waypointNode.transform.childCount; i++)
            {
                nodes.Add(waypointNode.transform.GetChild(i));
            }
            currentNum = 0;
            this.GetComponent<Rigidbody>().centerOfMass = CenterOfMess.localPosition;
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        void FixedUpdate()
        {
            AISteer();
            CalMinDistanceWaypoint();
            PlayToque();
        }

        void PlayToque()
        {
            if (vertical != 0)
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = maxToque * vertical;
                }
            }

            if (horizontal != 0)
            {
                for (int i = 0; i < wheels.Length - 2; i++)
                {
                    wheels[i].steerAngle = maxToque * horizontal;
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

        void AISteer()
        {
            Vector3 relative = transform.InverseTransformPoint(nodes[currentNum].position);

            relative /= relative.magnitude;
            horizontal = (relative.x / relative.magnitude) * steerForce;
        }

        void CalMinDistanceWaypoint()
        {
            if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                new Vector2(nodes[currentNum].position.x, nodes[currentNum].position.z)) < minDistance)
            {
                currentNum++;
            }
        }
    }
}
