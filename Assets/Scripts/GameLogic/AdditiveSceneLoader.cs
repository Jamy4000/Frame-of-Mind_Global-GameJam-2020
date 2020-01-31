using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ.GameLogic
{
    public class AdditiveSceneLoader : MonoBehaviour
    {
        [SerializeField] private string[] _additiveScenesNames;

        private void Awake()
        {
            foreach (var scene in _additiveScenesNames)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
        }
    }
}