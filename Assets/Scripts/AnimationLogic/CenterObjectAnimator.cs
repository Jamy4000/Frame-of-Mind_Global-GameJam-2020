using UnityEngine;

namespace GGJ.AnimationLogic
{
    public class CenterObjectAnimator : MonoBehaviour
    {
        private Animator _animator;

        private int _animIndex = 0;
        private bool _startRotating;

        private float _timeSinceRotatinBegan;
        private float _timeBeforeRotationEnd = 6.0f;
        [SerializeField]
        private float _rotationSpeed = 5.0f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            OnLaserBeamReachedCenter.Listeners += AnimateCenterObject;
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.A))
                AnimateCenterObject(null);

            if (_startRotating)
            {
                transform.Rotate(new Vector3(Time.deltaTime + 0.6f, Time.deltaTime + 0.4f, 0.0f) * _rotationSpeed);
                _timeSinceRotatinBegan += Time.deltaTime;

                if (_timeSinceRotatinBegan > _timeBeforeRotationEnd)
                    _rotationSpeed -= Time.deltaTime * 20;
                if (_rotationSpeed <= 0.0f)
                {
                    _startRotating = false;
                }
            }
        }

        private void OnDestroy()
        {
            OnLaserBeamReachedCenter.Listeners -= AnimateCenterObject;
        }

        private void AnimateCenterObject(OnLaserBeamReachedCenter info)
        {
            switch (_animIndex)
            {
                case 0:
                    Debug.Log("FIRST ANIM");
                    _animator.SetTrigger("FirstAnimation");
                    break;
                case 1:
                    Debug.Log("SECOND ANIM");
                    _animator.SetTrigger("SecondAnimation");
                    break;
                case 2:
                    Debug.Log("THIRD ANIM");
                    _animator.SetTrigger("ThirdAnimation");
                    break;
                    default:
                    Debug.Log("EXCUSEMEWTF");
                    break;
            }
            _animIndex++;
        }

        public void StartRotating()
        {
            _startRotating = true;
        }
    }
}
