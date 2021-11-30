using UnityEngine;


public abstract class Collectables : MonoBehaviour
    {
        protected Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _player.CollisionWithTrigger += Reached;
            
        }
        private void OnDisable()
        {
            _player.CollisionWithTrigger -= Reached;
            
        }

        protected abstract void Reached(Collider other);
        
    }