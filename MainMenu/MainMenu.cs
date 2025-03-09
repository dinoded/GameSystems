using UnityEngine;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using CustomTools;
#endif

namespace UI.MainMenu 
{
    /// <summary>
    /// Manages the main menu functionality.
    /// </summary>
    public class MainMenu : MonoBehaviour // TODO: add better comments
    {
        [SerializeField] private GameObject _optionsMenu;
        [SerializeField] private GameObject _soundOptionsMenu;
        [SerializeField] private GameObject _graphicsOptionsMenu;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _graphicsButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _loadGameButton;

        [SerializeField] private bool _isSoundOptionsOpened;
        [SerializeField] private bool _isGraphicsOptionsOpened;
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private string _id;

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_id))
            {
                GenerateNewID();
            }
        }

        private void Start()
        {
            InitializeMenus();
            SetupButtonListeners();
        }
#if UNITY_EDITOR
        [Button]
#endif
        public void GenerateNewID()
        {
            _id = Guid.NewGuid().ToString();
        }

        private void InitializeMenus()
        {
            _optionsMenu.SetActive(false);
            _soundOptionsMenu.SetActive(false);
            _graphicsOptionsMenu.SetActive(false);
        }

        private void SetupButtonListeners()
        {
            _optionsButton.onClick.AddListener(OpenOptions);
            _exitButton.onClick.AddListener(ExitGame);
            _soundButton.onClick.AddListener(OpenSoundOptions);
            _graphicsButton.onClick.AddListener(OpenGraphicsOptions);
            _newGameButton.onClick.AddListener(NewGame);
            _loadGameButton.onClick.AddListener(LoadGame);
        }

        private void OpenOptions()
        {
            _optionsMenu.SetActive(true);
        }

        public void OpenSoundOptions()
        {
            _isSoundOptionsOpened = !_isSoundOptionsOpened;
            _soundOptionsMenu.SetActive(_isSoundOptionsOpened);
        }

        public void OpenGraphicsOptions()
        {
            _isGraphicsOptionsOpened = !_isGraphicsOptionsOpened;
            _graphicsOptionsMenu.SetActive(_isGraphicsOptionsOpened);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void NewGame()
        {
            
        }

        private void LoadGame()
        {
            
        }
    }
}