using UnityEngine;


    public abstract class PanelsHelper : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private Player _player;
        private UIPanel _uiPanel;
        private Control _playerControl;

        protected virtual void OnEnable()
        {
            _uiPanel = FindObjectOfType<UIPanel>(true);
            _player = FindObjectOfType<Player>();
            _playerControl = _player.GetComponent<Control>();
            
            _uiPanel.gameObject.SetActive(false);
            _playerControl.enabled = false;

            Time.timeScale = 0;
            _audioSource.Pause();
            
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _audioSource.UnPause();
            
        }
        
        public virtual void PlayButtonPressed()
        {
            _uiPanel.gameObject.SetActive(true);
            _playerControl.enabled = true;
            gameObject.SetActive(false);
            
        }

    }
