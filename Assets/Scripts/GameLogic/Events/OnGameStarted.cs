namespace GGJ.GameLogic
{
    /// <summary>
    /// Event raised when the user press on a button to start the game
    /// </summary>
    public class OnGameStarted : EventCallbacks.Event<OnGameStarted>
    {
        /// <summary>
        /// Event raised when the user press on a button to start the game
        /// </summary>
        public OnGameStarted() : base("Event raised when the user press on a button to start the game")
        {
            FireEvent(this);
        }
    }
}
