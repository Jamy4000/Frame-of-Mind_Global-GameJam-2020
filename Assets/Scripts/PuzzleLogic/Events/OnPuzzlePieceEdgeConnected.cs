namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Event raised when the edge of a puzzle's piece is placed on its correct neighbor edge
    /// </summary>
    public class OnPuzzlePieceEdgeConnected : EventCallbacks.Event<OnPuzzlePieceEdgeConnected>
    {
        /// <summary>
        /// The piece's edge of a puzzle that has been connected
        /// </summary>
        public readonly PuzzlePieceEdge ConnectedPuzzlePieceEdge;

        /// <summary>
        /// Event raised when the edge of a puzzle's piece is placed on its correct neighbor edge
        /// </summary>
        /// <param name="connectedPuzzlePieceEdge">The piece's edge of a puzzle that has been connected</param>
        public OnPuzzlePieceEdgeConnected(PuzzlePieceEdge connectedPuzzlePieceEdge) : base ("Event raised when the edge of a puzzle's piece is placed on its correct neighbor edge")
        {
            ConnectedPuzzlePieceEdge = connectedPuzzlePieceEdge;

            FireEvent(this);
        }
    }
}
