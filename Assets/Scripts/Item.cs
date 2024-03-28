using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        public enum ItemStatus
        {
            gold1,
            gold2,
            gold3,
            speedUp1,
            speedUp2,
            openMiniStore
        }
        public int[] gold =
        {
        1000000,
        5000000,
        10000000
    };
        public ItemStatus status;

        DriftTestScript Car;
        GameData gameData;
        // Start is called before the first frame update
        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                SetItem(other.transform);
            }
        }

        void SetItem(Transform other)
        {
            Debug.Log("SetItem");
            switch (status)
            {
                case ItemStatus.gold1:
                    gameData.gold += gold[0];
                    break;
                case ItemStatus.gold2:
                    gameData.gold += gold[1];
                    break;
                case ItemStatus.gold3:
                    gameData.gold += gold[2];
                    break;
                case ItemStatus.speedUp1:
                    other.GetComponent<Rigidbody>().AddForce(other.forward * 50000, ForceMode.Impulse);
                    break;
                case ItemStatus.speedUp2:
                    other.GetComponent<Rigidbody>().AddForce(other.forward * 100000, ForceMode.Impulse);
                    break;

                    //case ItemStatus.engine1:
                    //    if(gameData.engineNum < 1)
                    //    {
                    //        gameData.engineNum = 1;
                    //    }
                    //    break;
                    //    case ItemStatus.engine2:
                    //    if(gameData.engineNum < 2)
                    //    {
                    //        gameData.engineNum = 2;
                    //    }
                    //    break;
            }
        }
    }
}
