using UnityEngine;

namespace Barrier
{
    public class CollectablesSpawner : Spawner
    {
        [SerializeField] private Collectables[] _prefabs;
        
        private void OnEnable()
        {
            _roadSpawner.OnRoadSpawnEnded += StartSpawning;
            
        }
        private void OnDisable()
        {
            _roadSpawner.OnRoadSpawnEnded -= StartSpawning;
            
        }
        
        protected override void SpawnTo(Road road)
        {
            var roadPosition = road.transform.position;

            for (int i = 0; i < _count; i++)
            {
                Collectables lastTimeSpawned = null;

                foreach (var spawnPoint in _spawnPoints)
                {
                    var spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, roadPosition.z - 5f -  i * 5f);

                    var toSpawn = GetCollectableForSpawn(lastTimeSpawned);
                    lastTimeSpawned = toSpawn;
                    var obj = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
                    obj.transform.SetParent(road.transform);
                    
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
        
    }
    
}