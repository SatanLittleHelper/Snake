using UnityEngine;

namespace Barrier
{
    public class CollectablesSpawner : Spawner
    {
        [SerializeField] private Collectables[] _prefabs;
       
        private void OnEnable()
        {
            _roadSpawner.RoadSpawnEnded += StartSpawning;
            
        }
        private void OnDisable()
        {
            _roadSpawner.RoadSpawnEnded -= StartSpawning;
            
        }
        
        protected override void SpawnTo(Road road)
        {
            var roadPosition = road.transform.position;

            for (int i = 0; i < _count; i++)
            {
                Collectables lastTimeSpawned = null;

                foreach (var spawnPoint in _spawnPoints)
                {
                    var toSpawn = GetCollectableForSpawn(lastTimeSpawned);
                    var boundsY = toSpawn.GetComponent<MeshRenderer>().bounds.size.y ;
                    var spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y * boundsY, roadPosition.z - 5f -  i * 5f);
                    var obj = Instantiate(toSpawn, spawnPosition, Quaternion.Euler(new Vector3(-90f,0,0)));
                    
                    lastTimeSpawned = toSpawn;
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