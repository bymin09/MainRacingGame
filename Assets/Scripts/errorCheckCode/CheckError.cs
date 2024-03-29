using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class CheckError : MonoBehaviour
    {
        public Canvas ErrorStart;

        void OnTriggerEnter(Collider other)
        {
            ErrorStart.gameObject.SetActive(true);
        }
    }
}
