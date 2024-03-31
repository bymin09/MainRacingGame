using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class PingController : MonoBehaviour
    {
        public float height = 100.0f;

        public Transform Player;

        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void Update()
        {
            this.transform.position = Player.position + Vector3.up * height;
        }
    }
}
