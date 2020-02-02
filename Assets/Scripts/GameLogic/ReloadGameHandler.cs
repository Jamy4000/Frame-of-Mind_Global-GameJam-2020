using UnityEngine;

namespace GGJ.GameLogic
{
    public class ReloadGameHandler : MonoBehaviour
    {
        [SerializeField]
        private float _timeBeforeReload = 5.0f;

        private float _timerSinceStartClicking = 0.0f;

        public void OnMenuButtonIsClicking()
        {
            _timerSinceStartClicking += Time.deltaTime;
            if (_timerSinceStartClicking > _timeBeforeReload)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }

        public void OnStopClicking()
        {
            _timerSinceStartClicking = 0.0f;
        }
    }
}
