using System.Collections.Generic;
using UnityEngine;

namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// Script placed on each puzzle pieces, dissolve it when an error occur
    /// </summary>
    public class PuzzlePieceDissolver : MonoBehaviour
    {
        private PuzzlePiece _puzzlePiece;
        private MeshRenderer _renderer;

        private bool _isDissolving;
        private bool _isAppearing;
        private float _currentDissolveFactor = 0.0f;
        //Dissolve Parameter : Vector1_FEFF47F1

        private void Awake() 
        {
            OnConnectionErrorBetweenPieces.Listeners += ConnectionErrorCallback;
            _puzzlePiece = GetComponent<PuzzlePiece>();
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update() 
        {
            if (_isDissolving) 
            {
                _currentDissolveFactor += Time.deltaTime;
                _renderer.material.SetFloat("Vector1_FEFF47F1", _currentDissolveFactor);
                if (_currentDissolveFactor >= 1.0f) 
                {
                    _isDissolving = false;
                    _puzzlePiece.ResetPuzzlePiece();
                    _isAppearing = true;
                }
            }
            else if (_isAppearing) 
            {
                _currentDissolveFactor -= Time.deltaTime;
                _renderer.material.SetFloat("Vector1_FEFF47F1", _currentDissolveFactor);
                if (_currentDissolveFactor <= 0.0f) 
                    _isAppearing = false;
            }
        }

        private void OnDestroy() 
        {
            OnConnectionErrorBetweenPieces.Listeners -= ConnectionErrorCallback;
        }

        /// <summary>
        /// Callback for when an error is made by the user, reset the puzzle back to its basic place
        /// </summary>
        /// <param name="_"></param>
        private void ConnectionErrorCallback(OnConnectionErrorBetweenPieces _)
        {
            _isDissolving = true;
        }
    }
}
