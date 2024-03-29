using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class PingController : MonoBehaviour
    {
        public Transform Player;
        public void Update()
        {
            this.transform.position = Player.position + Vector3.up;
        }
    }
}
