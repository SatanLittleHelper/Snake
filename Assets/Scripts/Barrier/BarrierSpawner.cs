using System.Collections.Generic;
using UnityEngine;

namespace Barrier
{
    public class BarrierSpawner : MonoBehaviour
    {
        [SerializeField] private Collectables[] _prefabs;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private int _barrierCount;
        [SerializeField] private RoadSpawner _roadSpawner;
        private List<Collectables> _collectables;

        private void OnEnable()
        {
            _roadSpawner.OnRoadSpawnEnded += StartSpawning;
        }
        private void OnDisable()
        {
            _roadSpawner.OnRoadSpawnEnded -= StartSpawning;
        }

        private void Spawn(Road road)
        {
            var roadPosition = road.transform.position;

            for (int i = 0; i <= _barrierCount; i++)
            {
                foreach (var spawnPoint in _spawnPoints)
                {
                    spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, roadPosition.z - 5f -  i * 5f);
                    var obj = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], spawnPoint.position, Quaternion.identity);
                    obj.transform.SetParent(road.transform);
                    _collectables.Add(obj);
                }
               
            }
            


        }

        private void StartSpawning()
        {
            _collectables = new List<Collectables>();
            foreach (var road in _roadSpawner.AllRoads)
            {
                Spawn(road);
            }
        }
        
    }
}