using UnityEngine;

namespace GGJ.Tutorial
{
    /// <summary>
    /// When place on a tutorial object, activate it once we reached the correct tuto step
    /// </summary>
    public class TutorialObjectActivator : MonoBehaviour
    {
        [Header("Tutorial step on which object is activated")]
        [SerializeField] private ETutorialSteps _tutorialStepToActivate;
        
        private void Start()
        {
            if (_tutorialStepToActivate != ETutorialSteps.GRAB_FIRST_PIECE)
            {
                OnTutorialStepDone.Listeners += CheckNewTutoStep;
                gameObject.SetActive(false);
            }
        }
        
        private void OnDestroy()
        {
            if (OnTutorialStepDone.IsMethodAlreadyRegistered(CheckNewTutoStep))
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
        }

        private void CheckNewTutoStep(OnTutorialStepDone info)
        {
            switch (info.TutorialStepDone)
            {
                case ETutorialSteps.GRAB_FIRST_PIECE:
                    if (_tutorialStepToActivate == ETutorialSteps.PLACE_FIRST_PIECE)
                        ActivateObject();
                    break;
                case ETutorialSteps.PLACE_FIRST_PIECE:
                    if (_tutorialStepToActivate == ETutorialSteps.PLACE_REST_OF_PUZZLE)
                        ActivateObject();
                    break;
            }

            void ActivateObject()
            {
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
                gameObject.SetActive(true);
            }
        }
    }
}
