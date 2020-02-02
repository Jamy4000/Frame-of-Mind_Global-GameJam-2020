using GGJ.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Script taking care of the state of a puzzle
    /// </summary>
    public class Puzzle : MonoBehaviour
    {
        [SerializeField]
        private EPuzzles _thisPuzzle;

        [SerializeField]
        private List<PuzzlePiece> _puzzlePieces = new List<PuzzlePiece>();

        public bool IsCompleted;

        private int _connectedPiecesCount = 0;

        private void Awake()
        {
            if (_thisPuzzle == EPuzzles.TUTORIAL || _thisPuzzle == EPuzzles.SADNESS)
            {
                OnPuzzlePieceEdgeConnected.Listeners += OnPuzzlePieceConnectedCallback;
                OnConnectionErrorBetweenPieces.Listeners += ResetCounter;
            }
            else
            {
                OnPuzzleDone.Listeners += ActivateThisPuzzle;
            }
        }

        private void OnDestroy()
        {
            OnPuzzlePieceEdgeConnected.Listeners -= OnPuzzlePieceConnectedCallback;
            OnConnectionErrorBetweenPieces.Listeners -= ResetCounter;
            OnPuzzleDone.Listeners -= ActivateThisPuzzle;
        }

        private void OnPuzzlePieceConnectedCallback(OnPuzzlePieceEdgeConnected info)
        {
            _connectedPiecesCount++;
            if (_puzzlePieces.Count == _connectedPiecesCount)
            {
                OnPuzzlePieceEdgeConnected.Listeners -= OnPuzzlePieceConnectedCallback;
                OnConnectionErrorBetweenPieces.Listeners -= ResetCounter;
                Debug.Log("new OnPuzzleDone(_thisPuzzle) " + _thisPuzzle);
                new OnPuzzleDone(_thisPuzzle);
            }
        }

        private void ResetCounter(OnConnectionErrorBetweenPieces info)
        {
            _connectedPiecesCount = 0;
        }

        private void ActivateThisPuzzle(OnPuzzleDone info)
        {
            switch (info.EndedPuzzle)
            {
                case EPuzzles.SADNESS:
                    if (_thisPuzzle == EPuzzles.ANGER)
                    {
                        OnPuzzlePieceEdgeConnected.Listeners += OnPuzzlePieceConnectedCallback;
                        OnConnectionErrorBetweenPieces.Listeners += ResetCounter;
                    }
                    break;
                case EPuzzles.ANGER:
                    if (_thisPuzzle == EPuzzles.HAPINESS)
                    {
                        OnPuzzlePieceEdgeConnected.Listeners += OnPuzzlePieceConnectedCallback;
                        OnConnectionErrorBetweenPieces.Listeners += ResetCounter;
                    }
                    break;
                case EPuzzles.HAPINESS:
                    new GameLogic.OnGameEnded();
                    break;
                default:
                    Debug.LogError("ExcuseMeWhatTheFuck");
                    break;
            }
        }
    }
}
