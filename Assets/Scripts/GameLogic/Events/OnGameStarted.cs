namespace GGJ.GameLogic
{
    /// <summary>
    /// Event raised when the user grab the first piece of puzzle in front of him
    /// </summary>
    public class OnGameStarted : EventCallbacks.Event<OnGameStarted>
    {
        /// <summary>
        /// Event raised when the user grab the first piece of puzzle in front of him
        /// </summary>
        public OnGameStarted() : base("Event raised when the user grab the first piece of puzzle in front of him")
        {
            UnityEngine.Debug.Log("On Game Started !");
            Utils.GameStateHolder.CurrentPuzzle = Utils.EPuzzles.TUTORIAL;
            FireEvent(this);
        }
    }
}
