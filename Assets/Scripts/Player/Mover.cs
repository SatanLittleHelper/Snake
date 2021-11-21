    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Camera _camera;
        private Head _player;
        private RoadSpawner _spawner;
        private PlayerControl _control;
        private Road[] _allRoadElement;
        private Coroutine _moveCoroutine;

        public event UnityAction OnMoving;

        private void OnEnable()
        {
            _spawner.OnSpawnEnded += SpawnEnded;
        }
        private void OnDisable()
        {
            _spawner.OnSpawnEnded -= SpawnEnded;

        }
            

        private void Awake()
        {
            _player = FindObjectOfType<Head>();
            _spawner = FindObjectOfType<RoadSpawner>();
            _control = FindObjectOfType<PlayerControl>();
            _allRoadElement = FindObjectsOfType<Road>();
        }

        private void SpawnEnded()
        {
            StartMove();
           
        }
        
        private IEnumerator MoveRoutine (Vector3 dir)
        {
            {
                
                while (true)
                {
                    
                   Move(_player.gameObject, dir);
                   Move(_camera.gameObject, dir);
                   OnMoving?.Invoke();
                   
                    yield return null;
                   
                }
            }
        }

        private void Move(GameObject obj, Vector3 dir)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, obj.transform.position + dir, _speed * Time.deltaTime);

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
    }