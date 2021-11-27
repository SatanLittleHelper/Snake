using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        private Bounds _bounds;


        public Bounds Bounds => _bounds;
        public Vector3 Direction { get; set; }


        public float Sensitivity => _sensitivity;
        public event UnityAction<Collider> CollisionWithTrigger;

        private void Awake()
        {
            _bounds = GetComponent<MeshRenderer>().bounds;
        }

        private void OnTriggerEnter(Collider other)
        {
            CollisionWithTrigger?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            CollisionWithTrigger?.Invoke(other);
        }
    }
