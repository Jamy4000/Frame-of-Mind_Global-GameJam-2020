using GGJ.PuzzleLogic;
using VRSF.Core.Controllers;

namespace GGJ.Interactions
{
    /// <summary>
    /// Event raised whenever a piece is hovered by the user's controller, 
    /// and only if the user doesn't have a puzzle piece in its hand
    /// </summary>
    public class OnPuzzlePieceHovered : EventCallbacks.Event<OnPuzzlePieceHovered>
    {
        /// <summary>
        /// The piece of puzzle that is currently being hovered
        /// </summary>
        public readonly PuzzlePiece HoveredPuzzlePiece;

        /// <summary>
        /// 
        /// </summary>
        public readonly EHand HandHovering;

        /// <summary>
        /// Event raised whenever a piece is hovered by the user's controller, 
        /// and only if the user doesn't have a puzzle piece in its hand
        /// </summary>
        /// <param name="hoveredPuzzlePiece">The piece that is currently being hovered by the controllera</param>
        public OnPuzzlePieceHovered(PuzzlePiece hoveredPuzzlePiece, EHand handHovering) : base ("Event raised whenever a piece is hovered by the user's controller, and only if the user doesn't have a puzzle piece in its hand")
        {
            HoveredPuzzlePiece = hoveredPuzzlePiece;
            HandHovering = handHovering;
            FireEvent(this);
        }
    }
}
