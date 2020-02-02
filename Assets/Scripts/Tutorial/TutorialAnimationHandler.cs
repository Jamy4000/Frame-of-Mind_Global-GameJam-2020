using UnityEngine;

namespace GGJ.Tutorial
{
    public class TutorialAnimationHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            OnTutorialStepDone.Listeners += StartAnimationEndTuto;
            _animator = GetComponent<Animator>();
        }

        private void OnDestroy()
        {
            OnTutorialStepDone.Listeners -= StartAnimationEndTuto;
        }

        private void StartAnimationEndTuto(OnTutorialStepDone info)
        {
            if (info.TutorialStepDone == ETutorialSteps.PLACE_REST_OF_PUZZLE)
            {
                _animator.enabled = true;
                _animator.SetTrigger("TutoEnd");
                OnTutorialStepDone.Listeners -= StartAnimationEndTuto;
            }
        }
    }
}