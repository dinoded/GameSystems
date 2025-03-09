using UnityEngine;
using UnityEngine.UI;

namespace UI.Options
{
    /// <summary>
    /// Manages sound options in the game settings.
    /// </summary>
    public class SoundOptions : MonoBehaviour // TODO: add better comments
    {
        public Slider volumeSlider;

        public void CloseSoundOptions()
        {
            gameObject.SetActive(false);
        }
    }
}