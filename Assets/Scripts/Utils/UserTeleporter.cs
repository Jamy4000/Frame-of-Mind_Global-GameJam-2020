using GGJ.PuzzleLogic;
using System.Collections;
using UnityEngine;
using VRSF.Core.FadingEffect;

namespace GGJ.Utils
{
    public class UserTeleporter : MonoBehaviour
    {
        /// <summary>
        /// For which puzzle end are we waiting for before teleporting the user
        /// </summary>
        [SerializeField] private EPuzzles _thisPuzzle;
        [SerializeField] private Vector3 _newUserPosition;
        [SerializeField] private float _timeBeforeTeleport = 10.0f;

        private void Awake()
        {
            OnPuzzleDone.Listeners += CheckFinishedPuzzle;
        }

        private void OnDestroy()
        {
            OnPuzzleDone.Listeners -= CheckFinishedPuzzle;
        }

        private void CheckFinishedPuzzle(OnPuzzleDone info)
        {
            if (info.EndedPuzzle == _thisPuzzle)
                StartCoroutine(WaitForEndOfAnimation());

            IEnumerator WaitForEndOfAnimation()
            {
                OnPuzzleDone.Listeners -= CheckFinishedPuzzle;
                yield return new WaitForSeconds(_timeBeforeTeleport);
                OnFadingOutEndedEvent.Listeners += TeleportUser;
                new StartFadingOutEvent(true);
            }

            void TeleportUser(OnFadingOutEndedEvent _)
            {
                OnFadingOutEndedEvent.Listeners -= TeleportUser; 
                VRSF.Core.SetupVR.VRSF_Components.SetVRCameraPosition(_newUserPosition);
                //new StartFadingInEvent();
            }
        }
    }
}