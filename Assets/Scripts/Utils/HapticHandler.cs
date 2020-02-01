using UnityEngine;
using GGJ.Interactions;
using VRSF.Core.Controllers.Haptic;
using System.Collections;
using GGJ.PuzzleLogic;

namespace GGJ.Utils
{
    public class HapticHandler : MonoBehaviour
    {
        private void Awake()
        {
            OnPuzzlePieceGrabbed.Listeners += HapticOnGrab;
            OnPuzzlePieceHovered.Listeners += HapticOnHover;
            OnPuzzleDone.Listeners += HaticOnPuzzleDone;
            OnConnectionErrorBetweenPieces.Listeners += HaticOnError;
            OnPuzzlePieceEdgeConnected.Listeners += HaticOnCorrectConnection;
        }

        private void OnDestroy()
        {
            OnPuzzlePieceGrabbed.Listeners -= HapticOnGrab;
            OnPuzzlePieceHovered.Listeners -= HapticOnHover;
            OnPuzzleDone.Listeners -= HaticOnPuzzleDone;
            OnConnectionErrorBetweenPieces.Listeners -= HaticOnError;
            OnPuzzlePieceEdgeConnected.Listeners -= HaticOnCorrectConnection;
        }

        private void HapticOnHover(OnPuzzlePieceHovered info)
        {
            new OnHapticRequestedEvent(info.HandHovering, EHapticDuration.SHORT, EHapticAmplitude.LIGHT);
        }

        private void HapticOnGrab(OnPuzzlePieceGrabbed info)
        {
            StartCoroutine(DoubleVibration());

            IEnumerator DoubleVibration()
            {
                new OnHapticRequestedEvent(info.HandGrabbing, EHapticDuration.SHORT, EHapticAmplitude.MEDIUM);
                yield return new WaitForSeconds(0.6f);
                new OnHapticRequestedEvent(info.HandGrabbing, EHapticDuration.SHORT, EHapticAmplitude.MEDIUM);
            }
        }

        private void HaticOnPuzzleDone(OnPuzzleDone _)
        {
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.LEFT, EHapticDuration.LONG, EHapticAmplitude.MEDIUM);
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.RIGHT, EHapticDuration.LONG, EHapticAmplitude.MEDIUM);
        }

        private void HaticOnError(OnConnectionErrorBetweenPieces _)
        {
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.LEFT, EHapticDuration.LONG, EHapticAmplitude.LIGHT);
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.RIGHT, EHapticDuration.LONG, EHapticAmplitude.LIGHT);
        }

        private void HaticOnCorrectConnection(OnPuzzlePieceEdgeConnected _)
        {
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.LEFT, EHapticDuration.SHORT, EHapticAmplitude.LIGHT);
            new OnHapticRequestedEvent(VRSF.Core.Controllers.EHand.RIGHT, EHapticDuration.SHORT, EHapticAmplitude.LIGHT);
        }
    }
}