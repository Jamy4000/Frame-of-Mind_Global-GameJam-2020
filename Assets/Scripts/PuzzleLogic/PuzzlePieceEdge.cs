using UnityEngine;

namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Placed on the side a puzzle piece alongside a trigger box to check if the user is placing the piece correctly
    /// </summary>
    public class PuzzlePieceEdge : MonoBehaviour
    {
        /// <summary>
        /// Set in the in the inspector, the other edge that is expected to go with this one
        /// </summary>
        [Header("The edge that should be connected to this one")]
        public PuzzlePieceEdge ExpectedNeighbour;

        /// <summary>
        /// Is this an edge of the core ?
        /// </summary>
        [Header("Is this an edge of the core ?")]
        public bool IsCoreEdge;

        /// <summary>
        /// Set at runtime by the parent itself, reference to it
        /// </summary>
        [HideInInspector]
        public PuzzlePiece ParentPuzzlePiece;

        /// <summary>
        /// Let us know if this edge is connected ot its neighbor
        /// </summary>
        [HideInInspector]
        public bool IsConnected;
        
        /// <summary>
        /// The collider linked to this object
        /// </summary>
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            OnConnectionErrorBetweenPieces.Listeners += ConnectionErrorCallback;
            Interactions.OnPuzzlePieceGrabbed.Listeners += OnGrabPuzzlePieceCallback;

        }

        private void OnTriggerEnter(Collider other)
        {
            // if the trigger touching this object is another edge, we check if it's the right one
            if (other.CompareTag(Utils.TagHolder.PUZZLE_PIECE_EDGE))
                CheckConnectedPiece(other.GetComponent<PuzzlePieceEdge>());
        }

        private void OnDestroy()
        {
            OnConnectionErrorBetweenPieces.Listeners -= ConnectionErrorCallback;
            Interactions.OnPuzzlePieceGrabbed.Listeners -= OnGrabPuzzlePieceCallback;
        }

        /// <summary>
        /// Check if the other edge that just enter the trigger of this edge is the one that was expected
        /// </summary>
        /// <param name="edgeToCheck">The edge that entered the trigger of this edge</param>
        private void CheckConnectedPiece(PuzzlePieceEdge edgeToCheck)
        {
            // If the neighbor's expected edge is this one, this was correct
            if (edgeToCheck.ExpectedNeighbour == this)
            {
                IsConnected = true;
                _collider.enabled = false;

                // To avoid that the event is thrown two times
                if (!IsCoreEdge && !ParentPuzzlePiece.IsPlacedOnCore)
                    new OnPuzzlePieceEdgeConnected(this);
            }
            // To avoid that the event is thrown two times
            else if (!IsCoreEdge && !ParentPuzzlePiece.IsPlacedOnCore)
            {
                Debug.Log("New error !");
                new OnConnectionErrorBetweenPieces(ParentPuzzlePiece);
            }
        }

        /// <summary>
        /// Callback for when we correctly connect two edges together
        /// </summary>
        /// <param name="info"></param>
        private void OnPuzzlePieceCorrectlyPlacedCallback(OnPuzzlePieceEdgeConnected info)
        {
            // If this edge is not connected yet, but the puzzle piece that was connected is the same at the one this edge belongs to
            // This edge become then then next one on the core where we need to attach another piece of puzzle
            if (!IsConnected && info.ConnectedPuzzlePieceEdge.ParentPuzzlePiece == ParentPuzzlePiece)
                _collider.enabled = true;
        }

        /// <summary>
        /// Callback for when an error was made by the user, reset the variable and collider
        /// </summary>
        /// <param name="_"></param>
        private void ConnectionErrorCallback(OnConnectionErrorBetweenPieces _)
        {
            _collider.enabled = IsCoreEdge;
            IsConnected = false;
        }

        /// <summary>
        /// Callback for when we grab a puzzle piece, set the collider
        /// </summary>
        /// <param name="info"></param>
        private void OnGrabPuzzlePieceCallback(Interactions.OnPuzzlePieceGrabbed info)
        {
            // If this is an unconnected core edge, OR this edge is not connected, this is not a core edge AND the puzzle piece this edge belongs to is placed on the core OR the picked up puzzle piece is the parent of this edge
            _collider.enabled = (IsCoreEdge && !IsConnected) || (!IsConnected && !IsCoreEdge && ParentPuzzlePiece != null && ParentPuzzlePiece.IsPlacedOnCore) || info.GrabbedPuzzlePiece == ParentPuzzlePiece;
        }
    }
}
