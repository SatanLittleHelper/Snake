using UnityEngine;
using UnityEngine.Events;


public abstract class Collectables : MonoBehaviour
    {
        protected Player _player;
        public event UnityAction GameOver;

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

        protected void OnGameOver()
        {
            GameOver?.Invoke();
        }
    }