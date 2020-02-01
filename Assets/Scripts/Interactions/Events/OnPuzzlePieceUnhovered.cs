using GGJ.PuzzleLogic;

namespace GGJ.Interactions
{
    /// <summary>
    /// Event raised whenever a piece is hovered by the user's controller, 
    /// and only if the user doesn't have a puzzle piece in its hand
    /// </summary>
    public class OnPuzzlePieceUnhovered : EventCallbacks.Event<OnPuzzlePieceUnhovered>
    {
        /// <summary>
        /// The piece of puzzle that has been unhovered by the user's hand
        /// </summary>
        public readonly PuzzlePiece UnhoveredPuzzlePiece;

        /// <summary>
        /// Event raised whenever a piece was hovered by the user's controller and he removed his controllers model from it. 
        /// Only raised if the user doesn't have a puzzle piece in its hand
        /// </summary>
        /// <param name="unhoveredPuzzlePiece">The piece of puzzle that has been unhovered by the user's hand</param>
        public OnPuzzlePieceUnhovered(PuzzlePiece unhoveredPuzzlePiece) : base ("Event raised whenever a piece is hovered by the user's controller, and only if the user doesn't have a puzzle piece in its hand")
        {
            UnhoveredPuzzlePiece = unhoveredPuzzlePiece;

            FireEvent(this);
        }
    }
}
