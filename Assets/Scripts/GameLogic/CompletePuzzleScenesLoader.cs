using System;
using System.Collections;
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
        [SerializeField] private float _timeToWaitBeforeLoad = 15.0f;

        private void Awake()
        {
            OnTutorialStepDone.Listeners += CheckTutoStepDone;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                new PuzzleLogic.OnPuzzleDone(Utils.GameStateHolder.CurrentPuzzle);
            }
        }

        private void OnDestroy()
        {
            OnTutorialStepDone.Listeners -= CheckTutoStepDone;
        }

        private void CheckTutoStepDone(OnTutorialStepDone info)
        {
            if (info.TutorialStepDone == ETutorialSteps.PLACE_REST_OF_PUZZLE)
            {
                OnTutorialStepDone.Listeners -= CheckTutoStepDone;
                StartCoroutine(WaitBeforeLoadingScene());
            }
        }

        private IEnumerator WaitBeforeLoadingScene()
        {
            yield return new WaitForSeconds(_timeToWaitBeforeLoad);
            FinishLoadingPuzzlesScenes();
        }

        private void FinishLoadingPuzzlesScenes()
        {
            for (int i = 0; i < _sceneToLoadOnTutoEnd.Length; i++)
                SceneManager.LoadSceneAsync(_sceneToLoadOnTutoEnd[i], LoadSceneMode.Additive);
        }
    }
}
