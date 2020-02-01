namespace GGJ.GameLogic
{
    /// <summary>
    /// Event raised when the user resolved the last puzzle
    /// </summary>
    public class OnGameEnded : EventCallbacks.Event<OnGameEnded>
    {
        /// <summary>
        /// Event raised when the user resolved the last puzzle
        /// </summary>
        public OnGameEnded() : base("Event raised when the user resolved the last puzzle")
        {
            UnityEngine.Debug.Log("On Game Ended, Well done !");
            FireEvent(this);
        }
    }
}
