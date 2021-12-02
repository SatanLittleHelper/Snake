using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _speed;
        [SerializeField] private Material _feverMaterial;
        private Material _lastMaterial;
        private bool _feverEnable;
        
        private Fever _fever;


        public float Sensitivity => _sensitivity;
        public float Speed => _speed;
        public event UnityAction<Collider> CollisionWithTrigger;

        private void Awake()
        {
            Time.timeScale = 1;
            _fever = FindObjectOfType<Fever>();
            
        }

        private void OnEnable()
        {
            _fever.FeverStarted += OnFever;
            _fever.FeverWillEndSoon += OnFeverWillEndSoon;
        }

        private void OnDisable()
        {
            _fever.FeverStarted -= OnFever;
            _fever.FeverWillEndSoon -= OnFeverWillEndSoon;
        }


        private void OnTriggerStay(Collider other)
        {
            CollisionWithTrigger?.Invoke(other);
            
            if (other.TryGetComponent(out Checkpoint checkpoint))
            {
                _lastMaterial = checkpoint.GetComponent<MeshRenderer>().material;
                if (_feverEnable) return;
                GetComponent<MeshRenderer>().material = _lastMaterial;

            }
            
        }
        
        private void OnFever(bool enable)
        {
            _feverEnable = enable;
            if (!enable)
            {
                GetComponent<MeshRenderer>().material = _lastMaterial;
                return;
            }
            _speed *= 3;
            _sensitivity *= 3;
            GetComponent<MeshRenderer>().material = _feverMaterial;


        }

        private void OnFeverWillEndSoon()
        {
            _speed /= 3;
            _sensitivity /= 3;

        }
        
    }
