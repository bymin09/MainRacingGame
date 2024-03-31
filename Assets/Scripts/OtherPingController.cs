using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class OtherPingController : MonoBehaviour
    {
        public float height = 100.0f;

        public Transform Enemy;

        void Start()
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        public void Update()
        {
            this.transform.position = Enemy.position + Vector3.up * height;
        }
    }
}
