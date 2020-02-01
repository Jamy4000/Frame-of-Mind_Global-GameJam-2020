using UnityEngine;

namespace GGJ.PuzzleLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class PuzzlePieceHelper : MonoBehaviour
    {
        [SerializeField]
        private PuzzlePiece _puzzlePiece;

        [SerializeField] private bool _isLinkedToCore;

        public void ActivateHelper()
        {
            if (_puzzlePiece.IsPlacedOnCore)
                return;

            gameObject.SetActive(true);
        }

        public void DeactivateHelper(bool resetting)
        {
            gameObject.SetActive(resetting ? _isLinkedToCore : false);
        }
    }
}
