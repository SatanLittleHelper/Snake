using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private MeshRenderer _renderer;
        private Bounds _bounds;


        public Bounds Bounds => _bounds;
        public Vector3 Direction { get; set; }


        public float Speed => _speed;
        public event UnityAction<Collider> OnCollisionWithTriger;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _bounds = _renderer.bounds;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCollisionWithTriger?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnCollisionWithTriger?.Invoke(other);
        }
    }
