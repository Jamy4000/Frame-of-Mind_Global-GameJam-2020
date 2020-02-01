using GGJ.PuzzleLogic;

namespace GGJ.Interactions
{
    /// <summary>
    /// Event raised whenever a piece is released by the user's, 
    /// and only if the user doesn't have a puzzle piece in its hand already
    /// </summary>
    public class OnPuzzlePieceReleased : EventCallbacks.Event<OnPuzzlePieceReleased>
    {
        /// <summary>
        /// The piece of puzzle that is being released
        /// </summary>
        public readonly PuzzlePiece ReleasedPuzzlePiece;

        /// <summary>
        /// Was the piece released from the hand after being correctly placed on the core ?
        /// </summary>
        public readonly bool ReleasedAfterBeingPlaced;

        /// <summary>
        /// Event raised whenever a piece is released by the user's, 
        /// and only if the user doesn't have a puzzle piece in its hand already
        /// </summary>
        /// <param name="releasedPuzzlePiece">The piece that is being released by the user</param>
        /// <param name="releasedAfterBeingPlaced">Was the piece released from the hand after being correctly placed on the core ?</param>
        public OnPuzzlePieceReleased(PuzzlePiece releasedPuzzlePiece, bool releasedAfterBeingPlaced) : base ("Event raised whenever a piece is released by the user's, and only if the user doesn't have a puzzle piece in its hand already")
        {
            ReleasedPuzzlePiece = releasedPuzzlePiece;
            ReleasedAfterBeingPlaced = releasedAfterBeingPlaced;

            FireEvent(this);
        }
    }
}
