using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ.Tutorial
{
    /// <summary>
    /// Load the scene with all puzzles once the tutorial is done
    /// </summary>
    public class CompletePuzzleScenesLoader : MonoBehaviour
    {
        [SerializeField] private string[] _sceneToLoadOnTutoEnd;

        private AsyncOperation[] _sceneLoadingAsyncOps;

        private void Awake()
        {
            OnTutorialStepDone.Listeners += CheckTutoStepDone;

            _sceneLoadingAsyncOps = new AsyncOperation[_sceneToLoadOnTutoEnd.Length];

            Debug.LogError("TODO Uncomment this once the scenes are completed, the loading is too fast right now");
            //// prepare the scenes to load on tuto ended, but do not activate them
            //for (int i = 0; i < _sceneToLoadOnTutoEnd.Length; i++)
            //{
            //    _sceneLoadingAsyncOps[i] = SceneManager.LoadSceneAsync(_sceneToLoadOnTutoEnd[i], LoadSceneMode.Additive);
            //    _sceneLoadingAsyncOps[i].allowSceneActivation = false;
            //}
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                new PuzzleLogic.OnPuzzleDone(Utils.GameStateHolder.CurrentPuzzle);
            }
            // Anger : 1.3 y + 0,2 size, forgot tags
        }

        private void CheckTutoStepDone(OnTutorialStepDone info)
        {
            if (info.TutorialStepDone == ETutorialSteps.PLACE_REST_OF_PUZZLE)
            {
                OnTutorialStepDone.Listeners -= CheckTutoStepDone;
                FinishLoadingPuzzlesScenes();
            }
        }

        private void FinishLoadingPuzzlesScenes()
        {
            for (int i = 0; i < _sceneToLoadOnTutoEnd.Length; i++)
                _sceneLoadingAsyncOps[i] = SceneManager.LoadSceneAsync(_sceneToLoadOnTutoEnd[i], LoadSceneMode.Additive);

            //Debug.LogError("TODO Uncomment this and comment the beginning of this method once the scenes are finished, the loading is too fast right now");
            //foreach (var asyncOp in _sceneLoadingAsyncOps)
            //    asyncOp.allowSceneActivation = true;
        }
    }
}
