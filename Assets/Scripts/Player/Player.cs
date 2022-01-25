using System;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _speed;
        [SerializeField] private Material _feverMaterial;
        private Material _lastMaterial;
        private bool _feverEnable;
        private Fever _fever;

        public bool FeverEnable => _feverEnable;
        public float Sensitivity => _sensitivity;
        public float Speed => _speed;
        public event Action<Collider> CollisionWithTrigger;


        private void Awake()
        {
            _fever = FindObjectOfType<Fever>();
            
        }

        private void OnEnable()
        {
            _fever.FeverStarted += OnFever;
            
        }

        private void OnDisable()
        {
            _fever.FeverStarted -= OnFever;
            
        }


        private void OnTriggerEnter(Collider other)
        {
            CollisionWithTrigger?.Invoke(other);

            if (!other.TryGetComponent(out Checkpoint checkpoint)) return;
            
            _lastMaterial = checkpoint.GetComponent<MeshRenderer>().material;
            _speed += 0.2f;

            if (_feverEnable) return;
            
            GetComponent<MeshRenderer>().material = _lastMaterial;

        }
        
        private void OnFever(bool state)
        {
            _feverEnable = state;
            ChangeSpeed(state);
            
            if (!state)
            {
                GetComponent<MeshRenderer>().material = _lastMaterial;
                return;
                
            }
            
            GetComponent<MeshRenderer>().material = _feverMaterial;

        }

        private void ChangeSpeed(bool state)
        {
            if (state)
            {
                _speed *= 2;
                
            }
            else
            {
                _speed /= 2;
                
            }
            
        }
        
    }
