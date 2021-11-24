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
            Collectables lastTimeSpawned = null;

            for (int i = 0; i <= _barrierCount; i++)
            {

                foreach (var spawnPoint in _spawnPoints)
                {

                    var toSpawn = GetCollectableForSpawn(lastTimeSpawned);
                    lastTimeSpawned = toSpawn;
                    Debug.Log(toSpawn);
                    spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, roadPosition.z - 5f -  i * 5f);
                    var obj = Instantiate(toSpawn, spawnPoint.position, Quaternion.identity);
                    obj.transform.SetParent(road.transform);
                    _collectables.Add(obj);
                }
               
            }
            


        }

        private Collectables GetCollectableForSpawn(Collectables lastTimeSpawned)
        {
            var toSpawn = _prefabs[Random.Range(0, _prefabs.Length)];
            if (lastTimeSpawned == toSpawn)
                toSpawn = GetCollectableForSpawn(toSpawn);

            return toSpawn;
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