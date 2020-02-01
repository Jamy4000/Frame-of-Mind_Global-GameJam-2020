using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.GameLogic;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class GameEndPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField]
        private PuzzleLogic.PuzzlePiece _puzzlePiece;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnGameStarted.Listeners -= StopSound;
            OnGameEnded.Listeners += PlaySound;
        }

        private void OnDestroy()
        {
            OnGameEnded.Listeners -= PlaySound;

        }

        private void PlaySound(OnGameEnded info)
        {
            _audioSource.Play();
        }

        private void StopSound(OnGameStarted info)
        {
            _audioSource.Stop();
        }
    }
}