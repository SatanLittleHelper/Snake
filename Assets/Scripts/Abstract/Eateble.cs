    using System;
    using UnityEngine;
    
    [RequireComponent(typeof(AudioSource))]
    public abstract class Eateble : Collectables
    {
        public event Action<AudioSource> PlaySound;
        private AudioSource _sound;

        private void OnEnable()
        {
            _mouth.Eat += OnEat;
            _sound = GetComponent<AudioSource>();

        }
        private void OnDisable()
        {
            _mouth.Eat -= OnEat;
            
        }

        private protected virtual void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Eateble eat)) return;
            PlaySound?.Invoke(_sound);
            eat.gameObject.SetActive(false);
            
           
        }

    }
