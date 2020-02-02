using GGJ.PuzzleLogic;
using UnityEngine;

namespace GGJ.Utils
{
    public class FogDeactivator : MonoBehaviour
    {
        [SerializeField] private EPuzzles _thisPuzzle;
        private ParticleSystem _fog;

        private void Awake()
        {
            OnPuzzleDone.Listeners += TurnOffFog;
            _fog = GetComponent<ParticleSystem>();
        }

        private void OnDestroy()
        {
            OnPuzzleDone.Listeners -= TurnOffFog;
        }

        private void TurnOffFog(OnPuzzleDone info)
        {
            if (info.EndedPuzzle == _thisPuzzle)
                _fog.Stop();
        }
    }
}