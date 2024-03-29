using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class CheckErrorEnd : MonoBehaviour
    {
        public Canvas ErrorEnd;

        void OnTriggerEnter(Collider other)
        {
            ErrorEnd.gameObject.SetActive(true);
        }
    }
}
