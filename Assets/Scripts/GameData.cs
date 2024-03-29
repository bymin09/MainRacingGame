using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mean
{
    public class GameData : MonoBehaviour
    {
        public int maxStageNum = 3;
        public string rank;
        public int tireNum = 0;
        public int engineNum = 0;
        public int stageNum = 0;
        public int sceneNum = 0;
        public int nowScene = 0;
        public int maxToque = 150;
        public int score = 0;
        public int gold = 10000;
        public int[] tireCost =
        {
            0,
            10000,
            100000,
            1000000,
        };
        public int[] engineCost =
        {
            0,
            2000000,
            20000000,
        };
        public bool cheatStore = false;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            rank = PlayerPrefs.GetString("Rank", "");
        }

        public void InitData()
        {
            tireNum = 0;
            engineNum = 0;
            stageNum = 0;
            maxToque = 150;
            score = 0;
            gold = 10000;
        }

        public void SetRank(string score)
        {
            if(rank == "")
            {
                rank = score;
            }
            else
            {
                rank += "|" + score;
            }
        }

        public void ChangeScene(int num)
        {
            sceneNum = num;
            SceneManager.LoadScene(num);
            nowScene = num;
            if(num > 1)
            {
                stageNum = num - 1; // ?
            }
        }

        public void ReStartScene(int num)
        {
            if(num == 1)
            {
                SceneManager.LoadScene(nowScene);
            }
        }

        public void SetStop(int num)
        {
            if (num == 0)
            {
                Time.timeScale = 0;
            }
            else if (num == 1)
            {
                Time.timeScale = 1;
            }
            else if(num == 2)
            {
                Time.timeScale = 0.5f;
            }
        }
    }
}
