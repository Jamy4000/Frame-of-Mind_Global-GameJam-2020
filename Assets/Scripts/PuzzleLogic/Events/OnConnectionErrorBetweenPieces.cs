namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Event raised when the edge of a puzzle's piece is wrongly placed on another piece's edge
    /// </summary>
    public class OnConnectionErrorBetweenPieces : EventCallbacks.Event<OnConnectionErrorBetweenPieces>
    {
        /// <summary>
        /// The piece of puzzle that was wrongly connected
        /// </summary>
        public readonly PuzzlePiece WronglyConnectedPiece;

        /// <summary>
        /// Event raised when the edge of a puzzle's piece is wrongly placed on another piece's edge
        /// </summary>
        /// <param name="wronglyConnectedPiece">The piece of puzzle that was wrongly connected</param>
        public OnConnectionErrorBetweenPieces(PuzzlePiece wronglyConnectedPiece) : base ("Event raised when the edge of a puzzle's piece is wrongly placed on another piece's edge")
        {
            WronglyConnectedPiece = wronglyConnectedPiece;

            FireEvent(this);
        }
    }
}
