    using System.Collections;
    using DefaultNamespace;
    using UnityEngine;
    using UnityEngine.Events;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Player _player;
        private RoadSpawner _spawner;
        private Coroutine _moveCoroutine;
        private Fever _fever;

        public event UnityAction Moving;

        private void OnEnable()
        {
            _spawner.RoadSpawnEnded += RoadSpawnEnded;
            _fever.FeverStarted += OnFever;
            _fever.FeverWillEndSoon += OnFeverWillEndSoon;
            
        }
        private void OnDisable()
        {
            _spawner.RoadSpawnEnded -= RoadSpawnEnded;
            _fever.FeverStarted -= OnFever;
            _fever.FeverWillEndSoon -= OnFeverWillEndSoon;

        }
            
        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _spawner = FindObjectOfType<RoadSpawner>();
            _fever = FindObjectOfType<Fever>();
            
        }
        
        private void RoadSpawnEnded()
        {
            StartMove();
           
        }

        private IEnumerator MoveRoutine(Vector3 dir)
        {
            while (_player)
            {
                Move(_player.gameObject, _player.transform.position + dir);
                Moving?.Invoke();

                yield return null;

            }
            
        }

        
        private void Move(GameObject obj, Vector3 target)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, _speed * Time.deltaTime);

        }

        private void StartMove()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
            
            _moveCoroutine = StartCoroutine(MoveRoutine(Vector3.forward));
            
        }

        private void OnFever(bool state)
        {
            if (state) _speed *= 3;
            
        }

        private void OnFeverWillEndSoon()
        {
            _speed /= 3;
            
        }
        
    }