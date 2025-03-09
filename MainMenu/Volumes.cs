using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    /// <summary>
    /// Controls various volume settings in the game.
    /// </summary>
    public class VolumeControl : MonoBehaviour // TODO: add better comments
    {
        [SerializeField] private Slider _generalVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;
        [SerializeField] private Slider _voiceVolumeSlider;

        [SerializeField] private AudioSource _generalAudioSource;
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioSource _sfxAudioSource;
        [SerializeField] private AudioSource _voiceAudioSource;

        [SerializeField] private const string GeneralVolumeKey = "GeneralVolume";
        [SerializeField] private const string MusicVolumeKey = "MusicVolume";
        [SerializeField] private const string SFXVolumeKey = "SFXVolume";
        [SerializeField] private const string VoiceVolumeKey = "VoiceVolume";

        private void Start()
        {
            InitializeVolumeSettings();
        }

        private void InitializeVolumeSettings()
        {
            SetVolumeFromPlayerPrefs(_generalVolumeSlider, GeneralVolumeKey, _generalAudioSource);
            SetVolumeFromPlayerPrefs(_musicVolumeSlider, MusicVolumeKey, _musicAudioSource);
            SetVolumeFromPlayerPrefs(_sfxVolumeSlider, SFXVolumeKey, _sfxAudioSource);
            SetVolumeFromPlayerPrefs(_voiceVolumeSlider, VoiceVolumeKey, _voiceAudioSource);
        }

        private void SetVolumeFromPlayerPrefs(Slider slider, string key, AudioSource audioSource)
        {
            float volume = PlayerPrefs.GetFloat(key, 0.5f);
            slider.value = volume;
            audioSource.volume = volume;
        }

        public void SetVolume(string type, float volume)
        {
            switch (type)
            {
                case "General":
                    SetVolumeForType(_generalAudioSource, GeneralVolumeKey, volume);
                    break;
                case "Music":
                    SetVolumeForType(_musicAudioSource, MusicVolumeKey, volume);
                    break;
                case "SFX":
                    SetVolumeForType(_sfxAudioSource, SFXVolumeKey, volume);
                    break;
                case "Voice":
                    SetVolumeForType(_voiceAudioSource, VoiceVolumeKey, volume);
                    break;
            }
        }

        private void SetVolumeForType(AudioSource audioSource, string key, float volume)
        {
            audioSource.volume = volume;
            PlayerPrefs.SetFloat(key, volume);
        }
    }
}