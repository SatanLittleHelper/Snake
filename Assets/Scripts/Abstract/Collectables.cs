using UnityEngine;


public abstract class Collectables : MonoBehaviour
    {
        [SerializeField] protected Player _player;

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