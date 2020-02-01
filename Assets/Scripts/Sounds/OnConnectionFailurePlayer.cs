using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Interactions;
using GGJ.PuzzleLogic;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class OnConnectionFailurePlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField]
        private PuzzleLogic.PuzzlePiece _puzzlePiece;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnConnectionErrorBetweenPieces.Listeners += PlaySound;
        }

        private void OnDestroy()
        {
            OnConnectionErrorBetweenPieces.Listeners -= PlaySound;

        }

        private void PlaySound(OnConnectionErrorBetweenPieces info)
        {
            _audioSource.Play();
        }
    }
}