    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class PlayerMover : MonoBehaviour
    {
        private Head _player;
        private RoadSpawner _spawner;
        private PlayerControl _control;

        public event UnityAction OnPlayerMove;

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
        }

        private void SpawnEnded()
        {
            StartCoroutine(MoveRoutine(Vector3.forward));
        }

        private IEnumerator MoveRoutine (Vector3 dir)
        {
            {
                // var startPosition = _startPosition;
                // var startPosition = _allObjects[0].transform.position;
                while (true)
                {
                    _player.transform.position = Vector3.MoveTowards(_player.transform.position, _player.transform.position + dir, _player.Speed * Time.deltaTime);
                    OnPlayerMove?.Invoke();
                    yield return null;
                   
                }
            }
        }
    }