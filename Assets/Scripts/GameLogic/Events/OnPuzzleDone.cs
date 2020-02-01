using GGJ.Utils;

namespace GGJ.GameLogic
{
    /// <summary>
    /// Event raised when the user finished a puzzle
    /// </summary>
    public class OnPuzzleDone : EventCallbacks.Event<OnPuzzleDone>
    {
        /// <summary>
        /// The puzzle that was finished by the user
        /// </summary>
        public readonly EPuzzles EndedPuzzle;

        /// <summary>
        /// Event raised when the user finished a puzzle
        /// </summary>
        /// <param name="endedPuzzle">The puzzle that was finished by the user</param>
        public OnPuzzleDone(EPuzzles endedPuzzle) : base("Event raised when the user finished a puzzle")
        {
            EndedPuzzle = endedPuzzle;

            FireEvent(this);
        }
    }
}
