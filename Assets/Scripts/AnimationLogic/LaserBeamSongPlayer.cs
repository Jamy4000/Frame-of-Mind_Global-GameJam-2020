using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.AnimationLogic
{
    public class LaserBeamSongPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayLaserSound()
        {
            _audioSource.Play();
        }
    }
}