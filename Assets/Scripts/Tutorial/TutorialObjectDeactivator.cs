using UnityEngine;

namespace GGJ.Tutorial
{
    /// <summary>
    /// When place on a tutorial object, deactivate it once we pass the specified step
    /// </summary>
    public class TutorialObjectDeactivator : MonoBehaviour
    {
        [Header("Tutorial step on which the object is deactivated")]
        [SerializeField] private ETutorialSteps _deactivateAfter;

        private void Awake()
        {
            OnTutorialStepDone.Listeners += CheckNewTutoStep;
        }

        private void OnDestroy()
        {
            if (OnTutorialStepDone.IsMethodAlreadyRegistered(CheckNewTutoStep))
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
        }

        private void CheckNewTutoStep(OnTutorialStepDone info)
        {
            if (info.TutorialStepDone == _deactivateAfter)
            {
                gameObject.SetActive(false);
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
            }
        }
    }
}
