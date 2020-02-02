using UnityEngine;

namespace GGJ.AnimationLogic
{
    public class LaserBeamInOrbEventRaiser : MonoBehaviour
    {
        /// <summary>
        /// Called from animation
        /// </summary>
        public void OnBeamReachedOrb()
        {
            new OnLaserBeamReachedCenter();
        }
    }
}