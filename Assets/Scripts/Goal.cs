using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class Goal : MonoBehaviour
    {
        [SerializeField]public Canvas GoalUI = new Canvas();
        [SerializeField]public Canvas LoseUI = new Canvas();
        //int Whowin;

        public GameData gameData;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        void OnTriggerEnter(Collider other)
        {
            //if(other.CompareTag("Player"))
            //{
            //    Whowin = 0;
            //}
            //else if (other.CompareTag("Enemy"))
            //{
            //    Whowin = 1;
            //}
            //switch (Whowin)
            //{
            //    case 0: GoalUI.gameObject.SetActive(true);
            //        break;
            //    case 1: LoseUI.gameObject.SetActive(true);
            //        break;
            //}
            if (other.CompareTag("Player"))
            {
                GoalUI.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                gameData.SetStop(0);
            }
            else if (other.CompareTag("Enemy"))
            {
                LoseUI.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                gameData.SetStop(0);
            }
        }
    }
}
