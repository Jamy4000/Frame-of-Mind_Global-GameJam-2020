using UnityEngine;

namespace GGJ.AnimationLogic
{
    public class CenterOrbGlower : MonoBehaviour
    {
        private Renderer _orbRenderer;

        [SerializeField]
        private Material[] _orbMaterials = new Material[4];

        private void Awake()
        {
            OnLaserBeamReachedCenter.Listeners += AddColorToBeam;
            _orbRenderer = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            OnLaserBeamReachedCenter.Listeners -= AddColorToBeam;
        }

        private void AddColorToBeam(OnLaserBeamReachedCenter info)
        {
            switch (Utils.GameStateHolder.CurrentPuzzle)
            {
                case Utils.EPuzzles.SADNESS:
                    _orbRenderer.materials = new Material[1] { _orbMaterials[0] };
                    break;
                case Utils.EPuzzles.ANGER:
                    _orbRenderer.materials = new Material[1] { _orbMaterials[1] };
                    break;
                case Utils.EPuzzles.HAPINESS:
                    _orbRenderer.materials = new Material[1] { _orbMaterials[2] };
                    break;
                default:
                    _orbRenderer.materials = new Material[1] { _orbMaterials[3] };
                    break;
            }
        }
    }
}
