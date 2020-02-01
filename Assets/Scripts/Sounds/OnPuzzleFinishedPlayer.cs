using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Interactions;
using GGJ.PuzzleLogic;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class OnPuzzleFinishedPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnPuzzleDone.Listeners += PlaySound;
        }

        private void OnDestroy()
        {
            OnPuzzleDone.Listeners -= PlaySound;

        }

        private void PlaySound(OnPuzzleDone info)
        {
            _audioSource.Play();
        }
    }
}