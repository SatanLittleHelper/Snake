    using DefaultNamespace;
    using UnityEngine;
    using UnityEngine.Audio;

    public class MainTheme : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        private AudioSource _mainTheme;
        private Fever _fever;
        private GameOverHandler _gameOverHandler;
        private float _pitchOffset = 0.005f;
        
        private void Awake()
        {
            _mainTheme = GetComponent<AudioSource>();
            _fever = FindObjectOfType<Fever>();
            _gameOverHandler = FindObjectOfType<GameOverHandler>();
            // вангую баг в будущем
            var snapshot = _audioMixer.FindSnapshot("Play");
            snapshot.TransitionTo(0f);

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
            var snapshot = _audioMixer.FindSnapshot("GameOver");
            snapshot.TransitionTo(0f);

        }
        
    }