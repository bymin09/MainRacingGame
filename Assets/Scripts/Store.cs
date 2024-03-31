using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class Store : MonoBehaviour
    {
        public float spotSpeed = 10.0f;

        //public mesh[] modelmeshs;
        //private meshfilter meshfilter;
        //public text textmodel;

        public string[] tireInfo =
        {
            "기본 타이어, $0",
            "사막 타이어, $10000",
            "산악 타이어, $100000",
            "도시 타이어, $1000000"
        };
        public int num = 0;
        public int ModelNum = 0;

        public Transform SpotCircle;
        public Text TextTire;
        public Text Gold;
        public GameData gameData;
        public GameObject Message;
        public GameObject[] tireMesh;
        public GameObject[] engineBuy;

        public int TireType; //0 : 없음, 1 : 사막, 2 : 숲, 3:도시
        //public int ForestTire = 0;
        //public int CityTire = 0;
        public bool SixEngine = false;
        public bool EightEngine = false;

        void Start()
        {
            //meshFilter = GetComponent<MeshFilter>();
            TextTire.text = tireInfo[num];
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
            Gold.text = "$" + gameData.gold.ToString();
            SetTire(gameData.tireNum);
            for(int i = 0; i < gameData.engineNum; i++)
            {
                engineBuy[i].SetActive(false);
            }
            //SetModel();
        }

        void Update()
        {
            SpotCircle.Rotate(Vector3.up * spotSpeed * Time.deltaTime);
        }

        void SetTire(int num)
        {
            for(int i = 0; i < tireMesh.Length; i++)
            {
                if(num == i)
                {
                    tireMesh[i].SetActive(true);
                }
                else
                {
                    tireMesh[i].SetActive(false);
                }
            }
        }

        public void BtnLeft()
        {
            num--;
            if(num < 0)
            {
                num = tireInfo.Length - 1;
            }
            TextTire.text = tireInfo[num];
            SetTire(num);
        }

        public void BtnRight()
        {
            num++;
            if(num > tireInfo.Length -1)
            {
                num = 0;
            }
            TextTire.text = tireInfo[num];
            SetTire(num);
        }

        public void BtnBuy()
        {
            if (gameData.gold < gameData.tireCost[num] && !gameData.cheatStore && TireType == 0)
            {
                if(num == 0)
                {

                }
                else
                {
                    Message.transform.GetComponent<Text>().text = "골드가 부족합니다.";
                    Message.SetActive(true);
                    Invoke("Hide", 1.0f);
                }
            }
            else if (TireType >= 1)
            {
                if (num == 0)
                {
                    Message.transform.GetComponent<Text>().text = "타이어가 변경되었습니다.";
                    Message.SetActive(true);
                    gameData.tireNum = num;

                    SetTire(num);
                    Invoke("Hide", 1.0f);
                }
                else
                {
                    Message.transform.GetComponent<Text>().text = "타이어가 변경되었습니다.";
                    Message.SetActive(true);
                    gameData.tireNum = num;

                    SetTire(num);
                    Invoke("Hide", 1.0f);
                }
            }
            else
            {
                if(num == 0)
                {

                }
                else
                {
                    Message.transform.GetComponent<Text>().text = "타이어를 구매하였습니다.";
                    Message.SetActive(true);
                    gameData.tireNum = num;

                    TireType = num;

                    if (!gameData.cheatStore)
                    {
                        gameData.gold -= gameData.tireCost[num];
                    }
                    SetTire(num);
                    Invoke("Hide", 1.0f);
                }
            }
            Gold.text = "$" + gameData.gold.ToString();
        }

        void Hide()
        {
            Message.SetActive(false);
        }

        public void BtnStart()
        {
            gameData.ChangeScene(gameData.stageNum = 2);
        }

        public void BtnBack()
        {
            gameData.ChangeScene(gameData.stageNum = 0);
        }

        public void BtnSixEngine()
        {
            if(gameData.gold < gameData.engineCost[1] && !gameData.cheatStore || !SixEngine == true)
            {
                Message.transform.GetComponent<Text>().text = "골드가 부족합니다.";
                Message.SetActive(true);
                Invoke("Hide", 1.0f);
            }
            else
            {
                Message.transform.GetComponent<Text>().text = "엔진이 변경되었습니다.";
                Message.SetActive(true);
                SixEngine = true;
                gameData.engineNum = 1;
                if (!gameData.cheatStore)
                {
                    gameData.gold -= gameData.engineCost[1];
                }
                Invoke("Hide", 1.0f);
            }
            Gold.text = "$" + gameData.gold.ToString();
        }

        public void BtnEightEngine()
        {
            if (gameData.gold < gameData.engineCost[2] && !gameData.cheatStore || !EightEngine == true)
            {
                Message.transform.GetComponent<Text>().text = "골드가 부족합니다.";
                Message.SetActive(true);
                Invoke("Hide", 1.0f);
            }
            else
            {
                Message.transform.GetComponent<Text>().text = "엔진이 변경되었습니다.";
                Message.SetActive(true);
                EightEngine = true;
                gameData.engineNum = 2;
                if (!gameData.cheatStore)
                {
                    gameData.gold -= gameData.engineCost[2];
                }
                Invoke("Hide", 1.0f);
            }
            Gold.text = "$" + gameData.gold.ToString();
        }

        //void SetModel()
        //{
        //    switch (ModelNum)
        //    {
        //        case 0:
        //            meshFilter.sharedMesh = ModelMeshs[0];
        //            break;
        //        case 1:
        //            meshFilter.sharedMesh = ModelMeshs[1];
        //            break;
        //        case 2:
        //            meshFilter.sharedMesh = ModelMeshs[2];
        //            break;
        //    }
        //}

        //public void BtnChangeModelRight()
        //{
        //    ModelNum++;
        //    if (ModelNum > 3)
        //    {
        //        ModelNum = 0;
        //    }
        //    switch (ModelNum)
        //    {
        //        case 0:
        //            meshFilter.sharedMesh = ModelMeshs[0];
        //            break;
        //        case 1:
        //            meshFilter.sharedMesh = ModelMeshs[1];
        //            break;
        //        case 2:
        //            meshFilter.sharedMesh = ModelMeshs[2];
        //            break;
        //    }
        //}

        //public void BtnChangeModelLeft()
        //{
        //    ModelNum--;
        //    if(ModelNum < 0)
        //    {
        //        ModelNum = 2;
        //    }
        //    switch (ModelNum)
        //    {
        //        case 0:
        //            meshFilter.sharedMesh = ModelMeshs[0];
        //            break;
        //        case 1:
        //            meshFilter.sharedMesh = ModelMeshs[1];
        //            break;
        //        case 2:
        //            meshFilter.sharedMesh = ModelMeshs[2];
        //            break;
        //    }
        //}
    }
}
