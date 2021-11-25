using UnityEngine;


public abstract class Collectables : MonoBehaviour
    {
        [SerializeField] protected Player _player;

        private void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _player.OnCollisionWithTriger += Reached;
            
        }
        private void OnDisable()
        {
            _player.OnCollisionWithTriger -= Reached;
            
        }

        protected abstract void Reached(Collider other);

    }