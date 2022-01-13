    using DefaultNamespace;
    using UnityEngine;

    public class MainTheme : MonoBehaviour
    {
        private AudioSource _mainTheme;
        private Fever _fever;
        private GameOverHandler _gameOverHandler;
        private float _pitchOffset = 0.005f;
        
        private void Awake()
        {
            _mainTheme = GetComponent<AudioSource>();
            _fever = FindObjectOfType<Fever>();
            _gameOverHandler = FindObjectOfType<GameOverHandler>();

        }

        private void OnEnable()
        {
            _fever.FeverStarted += OnFeverStarted;
            _gameOverHandler.GameOver += OnGameOver;

        }
        
        private void OnDisable()
        {
            _fever.FeverStarted -= OnFeverStarted;
            _gameOverHandler.GameOver -= OnGameOver;

        }

        private void OnFeverStarted(bool state)
        {
            if (state) _mainTheme.pitch = 1 + _pitchOffset + 0.1f ;
            else _mainTheme.pitch = 1 + _pitchOffset;
            _pitchOffset += 0.005f;

        }

        private void OnGameOver()
        {
            _mainTheme.Stop();
            
        }
        
    }