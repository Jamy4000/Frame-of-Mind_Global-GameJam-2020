using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ.Utils
{
    /// <summary>
    /// Load a list of scene as additive on awake
    /// </summary>
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