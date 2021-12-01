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
            var posibleoMaterial = GetAllPosibleMaterials(road);

            for (int i = 0; i < _count; i++)
            {
                Material lastMaterial = null;

                foreach (var spawnPoint in _spawnPoints)
                {
                    _humanSpawnPoints = HumanSpawnPoint.GetAllPosibleSpawnPoint();
                    var currentMaterial = GetHumanMaterial(posibleoMaterial, lastMaterial);
                    lastMaterial = currentMaterial;

                    for (int j = 0; j < _humansInOnePoint; j++)
                    {
                        var spawnPosition = spawnPoint.position;
                        spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, roadPosition.z + 5f +  i * 8f);
                        spawnPosition += GetHumanSpawnPosition();
                        var toSpawn = GetHumanForSpawn();
                        var obj = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
                        obj.GetComponent<MeshRenderer>().material = currentMaterial;
                        obj.transform.SetParent(road.transform);
                        
                    }
                    
                }
                    
            }

        }

        private Material[] GetAllPosibleMaterials(Road road)
        {
            var checkpointColor = road.GetComponentInChildren<Checkpoint>().GetComponent<MeshRenderer>().material;
            Material[] posibleoMaterial =
                {
                    checkpointColor,
                    _colors.GetRandomColorWithout(checkpointColor)
                };
            
            return posibleoMaterial;
            
        }

        private Material GetHumanMaterial(Material[] AllMaterial, Material lastMaterial)
        {
            if (lastMaterial == null) return AllMaterial[Random.Range(0, AllMaterial.Length)];

            var humanColor = AllMaterial[Random.Range(0, AllMaterial.Length)];
            if (humanColor.color == lastMaterial.color)
                humanColor = GetHumanMaterial(AllMaterial, lastMaterial);
            
            return humanColor;

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