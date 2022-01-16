    using DefaultNamespace;
    using UnityEngine;
    using UnityEngine.Audio;

    public class MainTheme : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        private AudioSource _mainTheme;
        private SoundSettings _soundSettings;
        private Fever _fever;
        private float _pitchOffset = 0.005f;
        
        private void Awake()
        {
            _mainTheme = GetComponent<AudioSource>();
            _fever = FindObjectOfType<Fever>();
            _soundSettings = FindObjectOfType<SoundSettings>();
            _soundSettings.ApplyUserSettings();

        }

        private void OnEnable()
        {
            _fever.FeverStarted += OnFeverStarted;

        }
        
        private void OnDisable()
        {
            _fever.FeverStarted -= OnFeverStarted;

        }

        private void OnFeverStarted(bool state)
        {
            if (state) _mainTheme.pitch = 1 + _pitchOffset + 0.1f ;
            else _mainTheme.pitch = 1 + _pitchOffset;
            _pitchOffset += 0.005f;

        }

    }