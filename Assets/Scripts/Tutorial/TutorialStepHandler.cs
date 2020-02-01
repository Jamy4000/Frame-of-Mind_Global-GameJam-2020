using GGJ.Interactions;
using GGJ.PuzzleLogic;
using UnityEngine;

namespace GGJ.Tutorial
{
    /// <summary>
    /// Handle the succession of tutorial steps
    /// </summary>
    public class TutorialStepHandler : MonoBehaviour
    {
        private void Awake()
        {
            OnPuzzlePieceGrabbed.Listeners += StartGame;
        }

        private void StartGame(OnPuzzlePieceGrabbed info)
        {
            OnPuzzlePieceGrabbed.Listeners -= StartGame;

            new GameLogic.OnGameStarted();
            new OnTutorialStepDone(ETutorialSteps.GRAB_FIRST_PIECE);

            OnPuzzlePieceEdgeConnected.Listeners += GoToLastTutoStep;
        }

        private void GoToLastTutoStep(OnPuzzlePieceEdgeConnected info)
        {
            OnPuzzlePieceEdgeConnected.Listeners -= GoToLastTutoStep;
            OnPuzzleDone.Listeners += FinishTuto;
            new OnTutorialStepDone(ETutorialSteps.PLACE_FIRST_PIECE);
        }

        private void FinishTuto(OnPuzzleDone info)
        {
            OnPuzzleDone.Listeners -= FinishTuto;
            new OnTutorialStepDone(ETutorialSteps.PLACE_REST_OF_PUZZLE);
        }
    }
}
