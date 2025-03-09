using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Sounds
{
    public class PlaySound : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioPreset;

        public void PlaySoundPreset()
        {
            EventManager.OnAudioClipPlay(transform, _audioPreset);
        }

        public void PlayNewSound(AudioClip audioClip)
        {
            EventManager.OnAudioClipPlay(transform, audioClip);
        }

    }
}
