using GGJ.PuzzleLogic;
using UnityEngine;

namespace GGJ.Interactions
{
    /// <summary>
    /// Interaction script to grab an item. Only one at a time, for both hands.
    /// </summary>
    [RequireComponent(typeof(HoverPieceHandler))]
    public class GrabPieceHandler : MonoBehaviour
    {
        /// <summary>
        /// The hovering system linked to this script, to know which object is currently hovered by the controller
        /// </summary>
        private HoverPieceHandler _hoverPieceHandler;

        /// <summary>
        /// The collider linked to this script
        /// </summary>
        private Collider _grabCollider;

        /// <summary>
        /// The currently grabed piece of puzzle
        /// </summary>
        private PuzzlePiece _grabedPuzzlePiece;

        /// <summary>
        /// To avoid that the user grab two pieces of puzzle at the same time with his two hands
        /// </summary>
        private static bool _isGrabbingSomething;

        private void Awake()
        {
            _hoverPieceHandler = GetComponent<HoverPieceHandler>();
            _grabCollider = GetComponent<Collider>();

            OnPuzzlePieceEdgeConnected.Listeners += PieceConnectedCallback;
            OnConnectionErrorBetweenPieces.Listeners += ErrorWithConnectionCallback;
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GrabPuzzlesPiece();
        }

        private void OnDestroy()
        {
            OnPuzzlePieceEdgeConnected.Listeners -= PieceConnectedCallback;
            OnConnectionErrorBetweenPieces.Listeners -= ErrorWithConnectionCallback;
        }

        /// <summary>
        /// Called from a CBRA when the user is clicking the Grip button
        /// </summary>
        public void GrabPuzzlesPiece()
        {
            // If nothing is hovered or something is already grabbed by the other hand
            if (_hoverPieceHandler.LastHoveredPiece == null || _isGrabbingSomething)
                return;

            _grabedPuzzlePiece = _hoverPieceHandler.LastHoveredPiece;
            _isGrabbingSomething = true;

            // We let the puzzle piece system know that we grabbed it
            _grabedPuzzlePiece.GrabPiece(transform);

            // We reset the hover system variables
            _hoverPieceHandler.CurrentlyHoveredPieces.Clear();
            _hoverPieceHandler.LastHoveredPiece = null;
            _grabCollider.enabled = false;

            new OnPuzzlePieceGrabbed(_grabedPuzzlePiece, _hoverPieceHandler.ThisHand);
        }

        /// <summary>
        /// Called from a CBRA when the user is releasing the Grip button
        /// </summary>
        public void OnGripButtonReleased()
        {
            if (_grabedPuzzlePiece == null)
                return;

            // we let the puzzle piece know that we want to release it
            _grabedPuzzlePiece.ReleasePieceFromHand();

            new OnPuzzlePieceReleased(_grabedPuzzlePiece, false);
            ResetVariables();
        }
        
        /// <summary>
        /// Callback for when an error is made by the user. Reset all variables
        /// </summary>
        /// <param name="info"></param>
        private void ErrorWithConnectionCallback(OnConnectionErrorBetweenPieces info)
        {
            ResetVariables();
        }

        /// <summary>
        /// Callback for when the user connect correctly two pieces. Reset all variables
        /// </summary>
        /// <param name="info"></param>
        private void PieceConnectedCallback(OnPuzzlePieceEdgeConnected info)
        {
            ResetVariables();
        }

        /// <summary>
        /// Reset the variables for this specific script
        /// </summary>
        private void ResetVariables()
        {
            _grabedPuzzlePiece = null;
            _grabCollider.enabled = true;
            _isGrabbingSomething = false;
        }
    }
}
