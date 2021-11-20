using UnityEngine;
using UnityEngine.Events;

    public class Head : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private MeshRenderer _renderer;
        private Bounds _bounds;
        private Vector3 _direction;


        public Bounds Bounds => _bounds;
        public Vector3 Direction
        {
            get => _direction;
            set => _direction = value;
        }


        public float Speed => _speed;
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
