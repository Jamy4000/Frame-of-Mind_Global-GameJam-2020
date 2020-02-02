using UnityEngine;

namespace GGJ.PuzzleLogic
{
    public class PuzzleAnimatorHandler : MonoBehaviour
    {
        [SerializeField]
        private float _animSpeed = 1.0f;

        private Puzzle _puzzle;
        private Animator _animator;

        private Vector3 _basePosition;

        private void Awake()
        {
            OnPuzzleDone.Listeners += StartAnimationEndPuzzle;
            _basePosition = transform.position;
            _animator = GetComponent<Animator>();
            _puzzle = GetComponent<Puzzle>();
        }

        private void Update()
        {
            if (_puzzle.IsCompleted)
            {
                if (transform.position.y <= _basePosition.y + 2.0f)
                    transform.position += new Vector3(0.0f, Time.deltaTime * _animSpeed, 0.0f);
                else
                    transform.position -= new Vector3(0.0f, Time.deltaTime * _animSpeed, 0.0f);
            }
        }

        private void OnDestroy()
        {
            OnPuzzleDone.Listeners -= StartAnimationEndPuzzle;
        }

        private void StartAnimationEndPuzzle(OnPuzzleDone info)
        {
            if (info.EndedPuzzle == _puzzle.ThisPuzzle)
            {
                _animator.enabled = true;
                _animator.SetTrigger("PuzzleDone");
                OnPuzzleDone.Listeners -= StartAnimationEndPuzzle;
            }
        }
    }
}