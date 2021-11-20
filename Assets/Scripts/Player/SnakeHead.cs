using System;
using UnityEngine;
using UnityEngine.Events;

    public class SnakeHead : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private Bounds _bounds;

        public Bounds Bounds => _bounds;
        public event UnityAction<Collider> OnCollisionWithBorder;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _bounds = _renderer.bounds;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCollisionWithBorder?.Invoke(other);
        }
        
    }
