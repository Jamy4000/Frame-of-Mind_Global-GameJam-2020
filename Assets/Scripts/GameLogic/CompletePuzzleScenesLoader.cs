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

        private void CheckTutoStepDone(OnTutorialStepDone info)
        {
            if (info.TutorialStepDone == ETutorialSteps.PLACE_REST_OF_PUZZLE)
            {
                OnTutorialStepDone.Listeners -= CheckTutoStepDone;
                VRSF.Core.FadingEffect.OnFadingOutEndedEvent.Listeners += FinishLoadingPuzzlesScenes;
            }
        }

        private void FinishLoadingPuzzlesScenes(VRSF.Core.FadingEffect.OnFadingOutEndedEvent _)
        {
            VRSF.Core.FadingEffect.OnFadingOutEndedEvent.Listeners -= FinishLoadingPuzzlesScenes;
            for (int i = 0; i < _sceneToLoadOnTutoEnd.Length; i++)
                SceneManager.LoadSceneAsync(_sceneToLoadOnTutoEnd[i], LoadSceneMode.Additive);
        }
    }
}
