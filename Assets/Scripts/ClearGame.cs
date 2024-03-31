using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class ClearGame : MonoBehaviour
    {
        public GameData gameData;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        public void BtnClear()
        {
            Debug.Log("test");
            gameData.stageNum++;
            if (gameData.stageNum > gameData.maxStageNum)
            {
                gameData.SetRank(gameData.gold.ToString());
                gameData.InitData();
                gameData.ChangeScene(0);
            }
            else
            {
                switch (gameData.stageNum)
                {
                    case 2:
                        {
                            gameData.gold += 100000;
                        }
                        break;
                    case 3:
                        {
                            gameData.gold += 1000000;
                        }
                        break;
                }
                gameData.ChangeScene(0);
            }
        }
    }
}

