    using UnityEngine;
    using UnityEngine.Events;

    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected RoadSpawner _roadSpawner;
        [SerializeField] protected int _count;
        [SerializeField] protected Transform[] _spawnPoints;
        public event UnityAction SpawnEnded;

        protected void StartSpawning()
        {
            for (int i = 1; i < _roadSpawner.AllRoads.Count; i++)
            {
                SpawnTo(_roadSpawner.AllRoads[i]);
                
            }
            SpawnEnded?.Invoke();

        }

        protected abstract void SpawnTo(Road road);

    }
