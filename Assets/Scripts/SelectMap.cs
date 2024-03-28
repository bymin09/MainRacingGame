using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class SelectMap : MonoBehaviour
    {
        public GameData gameData;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        public void BtnDesert()
        {
            gameData.ChangeScene(gameData.stageNum = 3);
        }
        public void BtnForest()
        {
            gameData.ChangeScene(gameData.stageNum = 4);
        }
        public void BtnCity()
        {
            gameData.ChangeScene(gameData.stageNum = 5);
        }
    }
}


