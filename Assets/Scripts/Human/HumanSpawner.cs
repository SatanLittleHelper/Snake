using Barrier;
using UnityEngine;

namespace Human
{
    public class HumanSpawner : Spawner
    {
        [SerializeField] private Human[] _prefabs;
        [SerializeField] private CollectablesSpawner _collectablesSpawner;
        private HumanSpawnPoint[] _humanSpawnPoints;
        private int _countOnPoint = 4;
        
        private void OnEnable()
        {
            _collectablesSpawner.OnSpawnEnded += StartSpawning;
        }
        private void OnDisable()
        {
            _collectablesSpawner.OnSpawnEnded -= StartSpawning;
        }
        


        protected override void SpawnTo(Road road)
        {
            var roadPosition = road.transform.position;

            for (int i = 0; i < _count; i++)
            {

                foreach (var spawnPoint in _spawnPoints)
                {
                    
                    // initHumanSpawnPoint();
                    _humanSpawnPoints = HumanSpawnPoint.GetAllPosibleSpawnPoint();

                    for (int j = 0; j < _countOnPoint; j++)
                    {
                        var spawnPosition = spawnPoint.position;
                        spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, roadPosition.z + 5f +  i * 8f);
                        spawnPosition += GetHumanSpawnPosition();
                        var toSpawn = GetHumanForSpawn();
                        var obj = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
                        obj.transform.SetParent(road.transform);
                    }
                }
                    
               
            }
            


        }
        private Human GetHumanForSpawn()
        {
            return _prefabs[Random.Range(0, _prefabs.Length)];
        }

        private void initHumanSpawnPoint()
        {
            HumanSpawnPoint zero = new HumanSpawnPoint();
            HumanSpawnPoint left = new HumanSpawnPoint();
            HumanSpawnPoint right = new HumanSpawnPoint();
            HumanSpawnPoint up = new HumanSpawnPoint();
            HumanSpawnPoint down = new HumanSpawnPoint();
            HumanSpawnPoint leftDown = new HumanSpawnPoint();
            HumanSpawnPoint rightDown = new HumanSpawnPoint();
            HumanSpawnPoint leftUp = new HumanSpawnPoint();
            HumanSpawnPoint rightUp = new HumanSpawnPoint();

            
            zero.Position = Vector3.zero;
            left.Position = new Vector3(-1f,0,0);
            right.Position = new Vector3(1f,0,0);
            up.Position = new Vector3(0, 0, 1f);
            down.Position = new Vector3(0, 0, -1);
            leftDown.Position = new Vector3(-1f,-1f,0);
            rightDown.Position = new Vector3(1f,-1f,0);
            leftUp.Position = new Vector3(-1f,1,0);
            rightUp.Position = new Vector3(1f,1,0);



            
            _humanSpawnPoints = new[] {zero, left, right, up, down, leftDown, leftUp, rightDown, rightUp};

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