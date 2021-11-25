
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected RoadSpawner _roadSpawner;
        [SerializeField] protected int _count;
        [SerializeField] protected Transform[] _spawnPoints;
        public event UnityAction OnSpawnEnded;

        protected void StartSpawning()
        {
            foreach (var road in _roadSpawner.AllRoads)
            {
                SpawnTo(road);
                
            }
            OnSpawnEnded?.Invoke();

        }

        protected abstract void SpawnTo(Road road);

    }
