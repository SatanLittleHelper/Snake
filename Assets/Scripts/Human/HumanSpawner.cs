using System;
using Barrier;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Human
{
    public class HumanSpawner : Spawner
    {
        [SerializeField] private Human[] _prefabs;
        [SerializeField] private CollectablesSpawner _collectablesSpawner;
        private HumanSpawnPoint[] _humanSpawnPoints;
        private int _humansInOnePoint = 4;
        private Colors _colors;

        private void Awake()
        {
            _colors = FindObjectOfType<Colors>();
        }

        private void OnEnable()
        {
            _collectablesSpawner.SpawnEnded += StartSpawning;
            
        }
        private void OnDisable()
        {
            _collectablesSpawner.SpawnEnded -= StartSpawning;
            
        }

        protected override void SpawnTo(Road road)
        {
            var roadPosition = road.transform.position;
            Material[] posibleoMaterial =
            {
                road.GetComponentInChildren<Checkpoint>().GetComponent<MeshRenderer>().material,
                _colors.AllColors[Random.Range(0, _colors.AllColors.Length)]
            };

            for (int i = 0; i < _count; i++)
            {
                foreach (var spawnPoint in _spawnPoints)
                {
                    _humanSpawnPoints = HumanSpawnPoint.GetAllPosibleSpawnPoint();
                    var humanColor = posibleoMaterial[Random.Range(0, posibleoMaterial.Length)];

                    for (int j = 0; j < _humansInOnePoint; j++)
                    {
                        var spawnPosition = spawnPoint.position;
                        spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, roadPosition.z + 5f +  i * 8f);
                        spawnPosition += GetHumanSpawnPosition();
                        var toSpawn = GetHumanForSpawn();
                        var obj = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
                        obj.GetComponent<MeshRenderer>().material = humanColor;
                        obj.transform.SetParent(road.transform);
                        
                    }
                    
                }
                    
            }

        }
        private Human GetHumanForSpawn()
        {
            return _prefabs[Random.Range(0, _prefabs.Length)];
            
        }

        private Vector3 GetHumanSpawnPosition()
        {
            var humanSpawnPoint = _humanSpawnPoints[Random.Range(0, _humanSpawnPoints.Length)];
            if (humanSpawnPoint.Taken)
               humanSpawnPoint.Position = GetHumanSpawnPosition();
            humanSpawnPoint.Taken = true;
            return humanSpawnPoint.Position;
            
        }
    }
}