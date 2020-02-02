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
        public EPuzzles ThisPuzzle;

        [SerializeField]
        private List<PuzzlePiece> _puzzlePieces = new List<PuzzlePiece>();
        [SerializeField]
        private GameObject _fullModel;
        [SerializeField]
        private GameObject _fracturedModel;

        public bool IsCompleted;

        private int _connectedPiecesCount = 0;

        private void Awake()
        {
            if (ThisPuzzle == EPuzzles.TUTORIAL || ThisPuzzle == EPuzzles.SADNESS)
            {
                OnPuzzlePieceEdgeConnected.Listeners += OnPuzzlePieceConnectedCallback;
                OnConnectionErrorBetweenPieces.Listeners += ResetCounter;
            }
            else
            {
                OnPuzzleDone.Listeners += ActivateThisPuzzle;
            }
        }

        private void Start()
        {
            if (ThisPuzzle != EPuzzles.TUTORIAL)
            {
                _fracturedModel.SetActive(true);
                _fullModel.SetActive(false);
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
                IsCompleted = true;
                if (ThisPuzzle != EPuzzles.TUTORIAL)
                {
                    _fracturedModel.SetActive(false);
                    _fullModel.SetActive(true);
                }
                new OnPuzzleDone(ThisPuzzle);
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
                    if (ThisPuzzle == EPuzzles.ANGER)
                    {
                        OnPuzzlePieceEdgeConnected.Listeners += OnPuzzlePieceConnectedCallback;
                        OnConnectionErrorBetweenPieces.Listeners += ResetCounter;
                    }
                    break;
                case EPuzzles.ANGER:
                    if (ThisPuzzle == EPuzzles.HAPINESS)
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
