﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Interactions;
using System;

namespace GGJ.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class GrabSoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField]
        private PuzzleLogic.PuzzlePiece _puzzlePiece;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            OnPuzzlePieceGrabbed.Listeners += PlaySound;
            OnPuzzlePieceReleased.Listeners += StopSound;
        }

        private void OnDestroy()
        {
            OnPuzzlePieceGrabbed.Listeners -= PlaySound;
            OnPuzzlePieceReleased.Listeners -= StopSound;
        }

        private void PlaySound(OnPuzzlePieceGrabbed info)
        {
            if (info.GrabbedPuzzlePiece == _puzzlePiece)
                _audioSource.Play();
        }

        private void StopSound(OnPuzzlePieceReleased info)
        {
            _audioSource.Stop();
        }
    }
}