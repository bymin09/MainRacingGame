using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class kmh : MonoBehaviour
    {
        public DriftTestScript carController;
        // Start is called before the first frame update
        void Start()
        {
            carController = GameObject.FindGameObjectWithTag("Player").GetComponent<DriftTestScript>();
        }

        // Update is called once per frame
        void Update()
        {
            if (carController != null)
            {
                this.GetComponent<Text>().text = carController.kmh + "km/h";
            }
        }
    }
}
