using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Interactions;
using GGJ.PuzzleLogic;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class OnConnectionSuccessPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnPuzzlePieceEdgeConnected.Listeners += PlaySound;
        }

        private void OnDestroy()
        {
            OnPuzzlePieceEdgeConnected.Listeners -= PlaySound;

        }

        private void PlaySound(OnPuzzlePieceEdgeConnected info)
        { 
                _audioSource.Play();
        }
    }
}