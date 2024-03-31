using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class CameraController : MonoBehaviour
    {
        //public Transform Player;
        //public float distance = 10.0f;
        //public float height = 5.0f;
        //public float smoothRotate = 5.0f;

        //void Start()
        //{
        //    Player = GameObject.FindGameObjectWithTag("Player").transform;

        //}

        //void Update()
        //{
        //    Follow();
        //}

        //void Follow()
        //{
        //    float yAngle = Mathf.LerpAngle(this.transform.eulerAngles.y, Player.eulerAngles.y, smoothRotate * Time.deltaTime);
        //    Quaternion rot = Quaternion.Euler(0, yAngle, 0);

        //    this.transform.position = Player.position + Vector3.up * height - rot * Vector3.forward * distance;
        //    this.transform.LookAt(Player);
        //}

        public GameObject Target = null;

        public GameObject T = null;

        public float speed = 2.0f;

        public int index;

        void Start()
        {
            Target = GameObject.FindGameObjectWithTag("Player");
            T = GameObject.FindGameObjectWithTag("Target");
        }

        void FixedUpdate()
        {
            this.transform.LookAt(Target.transform);
            float car_Move = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
            this.transform.position = Vector3.MoveTowards(this.transform.position, T.transform.position, car_Move * Time.deltaTime);
        }
    }
}
