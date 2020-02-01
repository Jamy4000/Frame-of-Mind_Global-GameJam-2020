using System.Collections.Generic;
using UnityEngine;

namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Script placed on each puzzle pieces, keep track of the current status of the piece
    /// </summary>
    public class PuzzlePiece : MonoBehaviour
    {
        /// <summary>
        /// Is the piece of puzzle already placed on the Puzzle's Core
        /// </summary>
        public bool IsPlacedOnCore = false;

        /// <summary>
        /// Where we should place the puzzle piece on Start and on Error. Assigned in editor.
        /// </summary>
        [SerializeField] [Tooltip("Where we should place the puzzle piece on Start and on Error")]
        private Transform _baseTransform;

        /// <summary>
        /// The parent where to replace this piece when placed on the core or released by the user
        /// </summary>
        private Transform _baseParent;

        /// <summary>
        /// The rigidbody attached to this piece of puzzle
        /// </summary>
        private Rigidbody _rb;

        /// <summary>
        /// The final position where to put this piece of puzzle on the completed puzzle
        /// </summary>
        private Vector3 _positionOnPuzzle;

        /// <summary>
        /// The final rotation of this piece of puzzle on the completed puzzle
        /// </summary>
        private Quaternion _rotationOnPuzzle;

        /// <summary>
        /// The list of edges, children of this piece of puzzle
        /// </summary>
        private List<PuzzlePieceEdge> _edges = new List<PuzzlePieceEdge>();

        private void Awake()
        {
            _positionOnPuzzle = transform.position;
            _rotationOnPuzzle = transform.rotation;
            _baseParent = transform.parent;
            _rb = GetComponent<Rigidbody>();

            foreach (var ppe in GetComponentsInChildren<PuzzlePieceEdge>())
            {
                _edges.Add(ppe);
                ppe.ParentPuzzlePiece = this;
            }

            OnPuzzlePieceEdgeConnected.Listeners += CheckConnectedPiece;
        }

        private void OnDestroy()
        {
            OnPuzzlePieceEdgeConnected.Listeners -= CheckConnectedPiece;
        }

        /// <summary>
        /// Method called by the GrabHandler system to grab this specific piece of puzzle
        /// </summary>
        /// <param name="newParent"></param>
        public void GrabPiece(Transform newParent)
        {
            _rb.useGravity = false;
            _rb.isKinematic = true;

            transform.SetParent(newParent);
            transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Make the puzzle piece fall on the ground
        /// </summary>
        public void ReleasePieceFromHand()
        {
            transform.SetParent(_baseParent);
            _rb.useGravity = !IsPlacedOnCore;
            _rb.isKinematic = IsPlacedOnCore;
        }

        /// <summary>
        /// Reset the puzzle piece after an error or after the disappearing effect
        /// </summary>
        public void ResetPuzzlePiece()
        {
            IsPlacedOnCore = false;
            ReleasePieceFromHand();
            transform.position = _baseTransform.position;
            transform.rotation = _baseTransform.rotation;
        }

        /// <summary>
        /// Callback for when two pieces are connected together
        /// Place this piece of puzzle correctly on the final puzzle
        /// </summary>
        /// <param name="info"></param>
        private void CheckConnectedPiece(OnPuzzlePieceEdgeConnected info)
        {
            if (_edges.Contains(info.ConnectedPuzzlePieceEdge))
                PlacePuzzlePieceOnCore();

            /// <summary>
            /// Place the puzzle piece on another one
            /// </summary>
            void PlacePuzzlePieceOnCore()
            {
                IsPlacedOnCore = true;
                ReleasePieceFromHand();
                transform.position = _positionOnPuzzle;
                transform.rotation = _rotationOnPuzzle;
            }
        }
    }
}
