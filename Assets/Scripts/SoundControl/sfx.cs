using DefaultNamespace.Player;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
    public class sfx: MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        private AudioSource _sfx;
        private Mouth _mouth;

        private void Awake()
        {
            _mouth = FindObjectOfType<Mouth>();
            _sfx = gameObject.AddComponent<AudioSource>();
            _sfx.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("Master/sfx")[0];

        }

        private void OnEnable()
        {
            _mouth.Eat += OnEat;

        }
        
        private void OnDisable()
        {
            _mouth.Eat -= OnEat;

        }
        
        private void OnEat(Collider other)
        {
            _sfx.clip = other.GetComponent<AudioSource>().clip;
            _sfx.Play();
            
        }
        
    }