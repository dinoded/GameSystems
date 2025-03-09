using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    /// <summary>
    /// Controls the SFX volume settings.
    /// </summary>
    public class SfxSetting : MonoBehaviour // TODO: add better comments
    {
        [SerializeField] private AudioMixer _myMixer;
        [SerializeField] private Slider _sfxSlider;

        private const string SfxVolumeParameter = "sfx";

        public void SetSfxVolume()
        {
            float volume = _sfxSlider.value;
            _myMixer.SetFloat(SfxVolumeParameter, volume);
        }
    }
}