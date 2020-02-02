using UnityEngine;

namespace GGJ.AnimationLogic
{
    public class LaserBeamInOrbEventRaiser : MonoBehaviour
    {
        /// <summary>
        /// Called from animation, not used with Tutorial.
        /// </summary>
        public void OnBeamReachedOrb()
        {
            new OnLaserBeamReachedCenter();
        }
        
        // reduce size of second puzzle, redo beam and placement
    }
}