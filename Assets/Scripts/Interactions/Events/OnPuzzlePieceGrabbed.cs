using GGJ.PuzzleLogic;
using VRSF.Core.Controllers;

namespace GGJ.Interactions
{
    /// <summary>
    /// Event raised whenever a piece is grabed by the user's, 
    /// and only if the user doesn't have a puzzle piece in its hand already
    /// </summary>
    public class OnPuzzlePieceGrabbed : EventCallbacks.Event<OnPuzzlePieceGrabbed>
    {
        /// <summary>
        /// The piece of puzzle that is currently Grabbed
        /// </summary>
        public readonly PuzzlePiece GrabbedPuzzlePiece;

        /// <summary>
        /// 
        /// </summary>
        public readonly EHand HandGrabbing;

        /// <summary>
        /// Event raised whenever a piece is grabed by the user's, 
        /// and only if the user doesn't have a puzzle piece in its hand already
        /// </summary>
        /// <param name="grabbedPuzzlePiece">The piece that is currently being Grabbed by the user</param>
        public OnPuzzlePieceGrabbed(PuzzlePiece grabbedPuzzlePiece, EHand handGrabbing) : base ("Event raised whenever a piece is grabed by the user's, and only if the user doesn't have a puzzle piece in its hand already")
        {
            GrabbedPuzzlePiece = grabbedPuzzlePiece;
            HandGrabbing = handGrabbing;

            FireEvent(this);
        }
    }
}
