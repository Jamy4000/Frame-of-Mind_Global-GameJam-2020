using GGJ.PuzzleLogic;
using System.Collections.Generic;
using UnityEngine;
using VRSF.Core.Controllers;

namespace GGJ.Interactions
{
    /// <summary>
    /// Script placed on controller to check if a piece is being hovered by the user's hand
    /// </summary>
    public class HoverPieceHandler : MonoBehaviour
    {
        /// <summary>
        /// The hand using this script, for haptic purposes
        /// </summary>
        public EHand ThisHand;

        /// <summary>
        /// The current pieces of puzzle that are being hovered by the user's hand. 
        /// Helpful for when the user hover multiple pieces of puzzles, keep track of at least one of the piece
        /// </summary>
        public List<PuzzlePiece> CurrentlyHoveredPieces = new List<PuzzlePiece>();

        /// <summary>
        /// The last hovered piece of puzzle, used in the Grab system
        /// </summary>
        public PuzzlePiece LastHoveredPiece;

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case Utils.TagHolder.PUZZLE_PIECE:
                    OnPieceHovered(other.GetComponent<PuzzlePiece>());
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            switch (other.tag)
            {
                case Utils.TagHolder.PUZZLE_PIECE:
                    OnStopHoveringAPiece(other.GetComponent<PuzzlePiece>());
                    break;
            }
        }

        /// <summary>
        /// Called when we hover a new piece that is not placed oon the core yet
        /// </summary>
        /// <param name="hoveredPuzzlePiece">The puzzle's piece that is currently being hovered</param>
        private void OnPieceHovered(PuzzlePiece hoveredPuzzlePiece)
        {
            if (hoveredPuzzlePiece.IsPlacedOnCore)
                return;

            CurrentlyHoveredPieces.Add(hoveredPuzzlePiece);
            LastHoveredPiece = hoveredPuzzlePiece;

            new OnPuzzlePieceHovered(hoveredPuzzlePiece, ThisHand);
        }

        /// <summary>
        /// When the user stop hovering a piece, we check if he wasn't hovering another piece at the same time
        /// </summary>
        /// <param name="unhoveredPuzzlePiece">The piec eof puzzle that was unhovered</param>
        private void OnStopHoveringAPiece(PuzzlePiece unhoveredPuzzlePiece)
        {
            // We don't care about the pieces of puzzles that are already placed on the core
            if (unhoveredPuzzlePiece.IsPlacedOnCore)
                return;

            // We remove the unhovered puzzle piece from the list
            CurrentlyHoveredPieces.Remove(unhoveredPuzzlePiece);
            new OnPuzzlePieceUnhovered(unhoveredPuzzlePiece);

            // If there's still a piece being hovered, we set it as the current hovered piece and raise the event again
            if (CurrentlyHoveredPieces.Count > 0)
            {
                LastHoveredPiece = CurrentlyHoveredPieces[CurrentlyHoveredPieces.Count - 1];
                new OnPuzzlePieceHovered(LastHoveredPiece, ThisHand);
            }
            else
            {
                LastHoveredPiece = null;
            }
        }
    }
}