using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class Store : MonoBehaviour
    {
        public float spotSpeed = 10.0f;

        public string[] tireInfo =
        {
            "�⺻ Ÿ�̾�, $0",
            "�縷 Ÿ�̾�, $10000",
            "��� Ÿ�̾�, $100000",
            "���� Ÿ�̾�, $1000000"
        };
        public int num = 0;

        public Transform SpotCircle;
        public Text TextTire;
        public Text Gold;
        public GameData gameData;
        public GameObject Message;
        public GameObject[] tireMesh;
        public GameObject[] engineBuy;

        void Start()
        {
            TextTire.text = tireInfo[num];
            gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
            Gold.text = "$" + gameData.gold.ToString();
            SetTire(gameData.tireNum);
            for(int i = 0; i < gameData.engineNum; i++)
            {
                engineBuy[i].SetActive(false);
            }
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
            if(num != 0)
            {
                if(gameData.gold < gameData.tireCost[num] && !gameData.cheatStore)
                {
                    Message.transform.GetComponent<Text>().text = "��尡 �����մϴ�.";
                    Message.SetActive(true);
                    Invoke("Hide", 1.0f);
                }
                else
                {
                    Message.transform.GetComponent<Text>().text = "Ÿ�̾ ����Ǿ����ϴ�.";
                    Message.SetActive(true);
                    gameData.tireNum = num;
                    if (!gameData.cheatStore)
                    {
                        gameData.gold -= gameData.tireCost[num];
                    }
                    SetTire(num);
                    Invoke("Hide", 1.0f);
                }
            }
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
            if(gameData.gold < gameData.engineCost[1] && !gameData.cheatStore)
            {
                Message.transform.GetComponent<Text>().text = "��尡 �����մϴ�.";
                Message.SetActive(true);
                Invoke("Hide", 1.0f);
            }
            else
            {
                Message.transform.GetComponent<Text>().text = "������ ����Ǿ����ϴ�.";
                Message.SetActive(true);
                gameData.engineNum = 1;
                if (!gameData.cheatStore)
                {
                    gameData.gold -= gameData.engineCost[1];
                }
                Invoke("Hide", 1.0f);
            }
        }

        public void BtnEightEngine()
        {
            if (gameData.gold < gameData.engineCost[2] && !gameData.cheatStore)
            {
                Message.transform.GetComponent<Text>().text = "��尡 �����մϴ�.";
                Message.SetActive(true);
                Invoke("Hide", 1.0f);
            }
            else
            {
                Message.transform.GetComponent<Text>().text = "������ ����Ǿ����ϴ�.";
                Message.SetActive(true);
                gameData.engineNum = 2;
                if (!gameData.cheatStore)
                {
                    gameData.gold -= gameData.engineCost[2];
                }
                Invoke("Hide", 1.0f);
            }
        }
    }
}
