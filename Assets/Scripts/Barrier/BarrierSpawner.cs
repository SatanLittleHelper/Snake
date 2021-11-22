using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Barrier
{
    public class BarrierSpawner : MonoBehaviour
    {
        [SerializeField] private Barrier _prefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private int _barrierCount;
        [SerializeField] private RoadSpawner _roadSpawner;
        private List<Barrier> _barriers;

        private void OnEnable()
        {
            _roadSpawner.OnRoadSpawnEnded += StartSpawningBarriers;
        }
        private void OnDisable()
        {
            _roadSpawner.OnRoadSpawnEnded -= StartSpawningBarriers;
        }

        private void SpawnBarriers(Road road)
        {
            var roadPosition = road.transform.position;

            for (int i = 0; i <= _barrierCount; i++)
            {
                var spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].localPosition;
                spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, roadPosition.z - i * 5f);
                var barrier = Instantiate(_prefab, spawnPosition, Quaternion.identity);
                barrier.transform.SetParent(road.transform);
                _barriers.Add(barrier);
            }
            


        }

        private void StartSpawningBarriers()
        {
            _barriers = new List<Barrier>();
            foreach (var road in _roadSpawner.AllRoads)
            {
                SpawnBarriers(road);
            }
        }
        
    }
}