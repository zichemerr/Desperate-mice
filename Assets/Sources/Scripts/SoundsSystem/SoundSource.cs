using System;
using UnityEngine;

namespace MerJame.SoundsSystem
{
    [Serializable]
    public class SoundSource
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clip;

        public AudioSource AudioSource => _audioSource;

        public void Init(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void Play(float volume = 1, bool loop = false)
        {
            Play(_clip, volume, loop);
        }

        public void Play(AudioClip clip, float volume = 1, bool loop = false)
        {
            _audioSource.loop = loop;
            _audioSource.volume = volume;
            _audioSource.PlayOneShot(clip);
        }

        public void Stop()
        {
            _audioSource.Stop();
        }
    }
}