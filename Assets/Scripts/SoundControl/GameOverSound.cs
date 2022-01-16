    using UnityEngine;
    using UnityEngine.Audio;
    
    [RequireComponent(typeof(AudioSource))]
    public class GameOverSound : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        private AudioSource _gameOver;
        private SoundSettings _soundSettings;

        private void Awake()
        {
            _soundSettings = FindObjectOfType<SoundSettings>();
            _gameOver = GetComponent<AudioSource>();
           
            if (!_soundSettings.LoadSettings()) return;
            var snapshot = _audioMixer.FindSnapshot("GameOver");
            snapshot.TransitionTo(0f);
            _gameOver.Play();

        }
        
        
    }
