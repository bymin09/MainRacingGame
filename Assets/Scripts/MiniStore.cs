using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mean
{
    public class MiniStore : MonoBehaviour
    {
        public Canvas MiniStoreUI;
        
        public void BtnExit()
        {
            MiniStoreUI.gameObject.SetActive(false);
        }
    }
}