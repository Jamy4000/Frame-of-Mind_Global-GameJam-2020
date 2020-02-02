using System;
using System.Collections;
using System.Collections.Generic;
using GGJ.GameLogic;
using UnityEngine;

namespace GGJ.Utils
{
    public class CreditSceneLoader : MonoBehaviour
    {
        [SerializeField] private string _creditScene = "Credits";

        private void Awake()
        {
            GameLogic.OnGameEnded.Listeners += LoadCreditScene;
        }

        private void OnDestroy()
        {
            GameLogic.OnGameEnded.Listeners += LoadCreditScene;
        }

        private void LoadCreditScene(OnGameEnded info)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_creditScene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}