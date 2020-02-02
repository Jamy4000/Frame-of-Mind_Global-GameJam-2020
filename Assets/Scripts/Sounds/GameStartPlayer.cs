using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.GameLogic;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class GameStartPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnGameStarted.Listeners += PlaySound;
        }

        private void OnDestroy()
        {
            OnGameStarted.Listeners -= PlaySound;

        }

        private void PlaySound(OnGameStarted info)
        {
            _audioSource.Play();
        }
    }
}