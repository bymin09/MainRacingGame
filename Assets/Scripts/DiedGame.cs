using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mean
{
    public class DiedGame : MonoBehaviour
    {
        public GameData gameData;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        public void BtnDied()
        {
            gameData.ChangeScene(0);
        }
    }
}
