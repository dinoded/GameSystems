using UnityEngine;
using System;
using CustomTools;

namespace UI.Options
{
    /// <summary>
    /// Manages the options menu functionality.
    /// </summary>
    public class OptionsMenu : MonoBehaviour // TODO: add better comments
    {
        public GameObject soundOptions;
        public GameObject graphicsOptions;

        [SerializeField]
        [ReadOnly]
        private string _id;

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_id))
            {
                GenerateNewID();
            }
        }

        [ContextMenu("Generate New ID")]
        public void GenerateNewID()
        {
            _id = Guid.NewGuid().ToString();
        }

        public void OpenSoundOptions()
        {
            soundOptions.SetActive(true);
        }

        public void OpenGraphicsOptions()
        {
            graphicsOptions.SetActive(true);
        }

        public void CloseOptionsMenu()
        {
            gameObject.SetActive(false);
        }
    }
}