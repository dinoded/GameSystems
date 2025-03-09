using UnityEngine;
using UnityEngine.UI;

namespace UI.Options
{
    /// <summary>
    /// Manages graphics options in the game settings.
    /// </summary>
    public class GraphicsOptions : MonoBehaviour
    {
        [SerializeField] private Dropdown _resolutionDropdown;

        private void Start()
        {
            _resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        }

        /// <summary>
        /// Closes the graphics options menu.
        /// </summary>
        public void CloseGraphicsOptions()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Changes the game resolution based on the selected dropdown value.
        /// </summary>
        /// <param name="resolutionIndex">Index of the selected resolution.</param>
        private void ChangeResolution(int resolutionIndex)
        {
            switch (resolutionIndex)
            {
                case 0:
                    Screen.SetResolution(1920, 1080, true);
                    break;
                case 1:
                    Screen.SetResolution(1280, 720, true);
                    break;
                case 2:
                    Screen.SetResolution(640, 480, true);
                    break;
            }
        }
    }
}