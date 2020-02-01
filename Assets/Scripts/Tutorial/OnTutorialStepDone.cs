namespace GGJ.Tutorial
{
    /// <summary>
    /// Raised when a tutorial step has been done
    /// </summary>
    public class OnTutorialStepDone : EventCallbacks.Event<OnTutorialStepDone>
    {
        /// <summary>
        /// The tutorial step that was done
        /// </summary>
        public readonly ETutorialSteps TutorialStepDone;

        /// <summary>
        /// Raised when a tutorial step has been done
        /// </summary>
        /// <param name="tutorialStepDone"></param>
        public OnTutorialStepDone(ETutorialSteps tutorialStepDone) : base("Raised when a tutorial step has been done")
        {
            TutorialStepDone = tutorialStepDone;
            UnityEngine.Debug.Log("Tutorial Step done ! " + tutorialStepDone);
            FireEvent(this);
        }
    }
}
