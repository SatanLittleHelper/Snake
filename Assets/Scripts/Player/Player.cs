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
            Time.timeScale = 1;
            _bounds = GetComponent<MeshRenderer>().bounds;
        }

       

        private void OnTriggerStay(Collider other)
        {
            CollisionWithTrigger?.Invoke(other);
            if (other.TryGetComponent(out Checkpoint checkpoint))
            {
                GetComponent<MeshRenderer>().material = checkpoint.GetComponent<MeshRenderer>().material;

            }
        }
    }
