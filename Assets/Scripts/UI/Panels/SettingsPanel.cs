using UnityEngine;
using UnityEngine.UI;


public class SettingsPanel : PanelsHelper
    {
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private Sprite _sound_on;
        [SerializeField] private Sprite _sound_off;
        [SerializeField] private Button _soundButton;
        private bool _soundState;
        private SoundSettings _soundSettings;

        private void Awake()
        {
            _soundSettings = FindObjectOfType<SoundSettings>();
            _soundState = _soundSettings.LoadSettings();
            ChangeIcon();
            
        }
        
        public void BackButtonPressed()
        {
            gameObject.SetActive(false);
            _pausePanel.gameObject.SetActive(true);

        }

        public void VolumeButtonPressed()
        {
            _soundState = _soundSettings.ChangeSoundState();
            ChangeIcon();

        }

        private void ChangeIcon()
        {
            _soundButton.image.sprite = _soundState ? _sound_on : _sound_off;
            
        }
        
    }
