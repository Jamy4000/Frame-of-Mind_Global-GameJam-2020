using UnityEngine;

namespace GGJ.Tutorial
{
    /// <summary>
    /// When place on a tutorial object, activate it once we reached the correct tuto step
    /// </summary>
    public class TutorialObjectActivator : MonoBehaviour
    {
        [Header("Tutorial step on which object is activated")]
        [SerializeField] private ETutorialSteps _tutorialStepToActivate;

        [SerializeField] private bool _isTransparentHelper;

        private Renderer _meshRenderer;
        
        private bool _isAppearing;
        private float _currentDissolveFactor = 0.0f;
        private Color _baseColor;
        //Dissolve Parameter : Vector1_FEFF47F1

        private void Start()
        {
            if (_tutorialStepToActivate != ETutorialSteps.GRAB_FIRST_PIECE)
            {
                OnTutorialStepDone.Listeners += CheckNewTutoStep;

                gameObject.SetActive(false);
                _meshRenderer = GetComponent<MeshRenderer>();

                if (!_isTransparentHelper)
                    _meshRenderer.material.SetFloat("Vector1_FEFF47F1", 0.0f);
                else
                {
                    _baseColor = _meshRenderer.material.color;
                    _meshRenderer.material.SetColor("_BaseColor", new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0.0f));
                }
            }
        }

        private void Update()
        {
            if (_isAppearing)
            {
                if (_isTransparentHelper)
                {
                    var currentAlpha = _meshRenderer.material.GetColor("_BaseColor").a;
                    if (currentAlpha < _baseColor.a)
                        _meshRenderer.material.SetColor("_BaseColor", new Color(_baseColor.r, _baseColor.g, _baseColor.b, currentAlpha + Time.deltaTime * 2));
                }
                else
                {
                    _currentDissolveFactor -= Time.deltaTime;
                    _meshRenderer.material.SetFloat("Vector1_FEFF47F1", _currentDissolveFactor);
                    if (_currentDissolveFactor <= 0.0f)
                        _isAppearing = false;
                }
            }
        }

        private void OnDestroy()
        {
            if (OnTutorialStepDone.IsMethodAlreadyRegistered(CheckNewTutoStep))
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
        }

        private void CheckNewTutoStep(OnTutorialStepDone info)
        {
            switch (info.TutorialStepDone)
            {
                case ETutorialSteps.GRAB_FIRST_PIECE:
                    if (_tutorialStepToActivate == ETutorialSteps.PLACE_FIRST_PIECE)
                        ActivateObject();
                    break;
                case ETutorialSteps.PLACE_FIRST_PIECE:
                    if (_tutorialStepToActivate == ETutorialSteps.PLACE_REST_OF_PUZZLE)
                        ActivateObject();
                    break;
            }

            void ActivateObject()
            {
                OnTutorialStepDone.Listeners -= CheckNewTutoStep;
                gameObject.SetActive(true);
                _isAppearing = true;
            }
        }
    }
}
