using Human;
using UnityEngine;

namespace DefaultNamespace.Abstract
{
    public abstract class Handler : MonoBehaviour
    {
        private HumanSpawner _spawner;
        protected Human.Human _human;
        
        protected virtual void Awake()
        {
            _spawner = FindObjectOfType<HumanSpawner>();
            
        }

        protected virtual void OnEnable()
        {
            _spawner.SpawnEnded += onSpawnEnded;
            
        }
        
        protected virtual void OnDisable()
        {
            _spawner.SpawnEnded -= onSpawnEnded;

        }
        
        protected virtual void onSpawnEnded()
        {
            _human = FindObjectOfType<Human.Human>();
            

        }


    }
}