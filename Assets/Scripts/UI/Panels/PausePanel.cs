using DefaultNamespace;
using UnityEngine;


public class PausePanel : PanelsHelper
    {
        [SerializeField] private SettingsPanel _settingsPanel;
        private HighscorePanel _highscorePanel;


        protected override void OnEnable()
        {
            base.OnEnable();
            _highscorePanel = FindObjectOfType<HighscorePanel>(true);
            _highscorePanel.gameObject.SetActive(true);
            
        }

        public void SettingsButtomPresed()
        {
            gameObject.SetActive(false);
            _highscorePanel.gameObject.SetActive(false);
            _settingsPanel.gameObject.SetActive(true);
           
        }

        public override void PlayButtonPressed()
        {           
            _highscorePanel.gameObject.SetActive(false);
            base.PlayButtonPressed();
            
        }
        
    }
