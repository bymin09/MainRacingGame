using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class MainMenu : MonoBehaviour
    {
        public GameData gameData;
        public Text TextRank;

        void Start()
        {
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
            SetRank();
            gameData.SetStop(1);
        }

        void Update()
        {

        }

        public void BtnStart()
        {
            gameData.ChangeScene(1);
        }

        public void BtnExit()
        {
            Application.Quit();
        }

        void SetRank()
        {
            if(gameData.rank == "")
            {
                TextRank.text = "- 랭킹 정보가 없습니다 -";
            }
            else
            {
                string[] temp = gameData.rank.Split('|');
                List<string> rankData = new List<string>();
                TextRank.text = "";
                for(int i = 0; i < temp.Length; i++)
                {
                    rankData.Add(temp[i]);
                }
                rankData.Sort();
                TextRank.text = "";
                for(int i = 0; i< temp.Length; i++)
                {
                    TextRank.text += temp[i] + System.Environment.NewLine;
                }
                foreach(string s in rankData)
                {
                    TextRank.text += s + System.Environment.NewLine;
                }
            }
        }
    }
}

