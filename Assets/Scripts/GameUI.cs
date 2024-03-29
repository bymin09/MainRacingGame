using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class GameUI : MonoBehaviour
    {
        public GameData gameData;
        public Image MenuBack;
        public Button MenuIcon;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        }

        public void BtnMenu()
        {
            MenuBack.gameObject.SetActive(true);
            MenuIcon.gameObject.SetActive(false);
        }

        public void BtnReStart()
        {
            gameData.ReStartScene(1);
        }

        public void BtnMenuConti()
        {
            MenuBack.gameObject.SetActive(false);
            MenuIcon.gameObject.SetActive(true);
        }

        public void BtnExit()
        {
            gameData.ChangeScene(0);
        }
    }
}
