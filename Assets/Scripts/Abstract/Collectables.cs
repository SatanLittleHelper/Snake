using DefaultNamespace.Player;
using UnityEngine;

public abstract class Collectables : MonoBehaviour
    {
        protected Player _player;
        protected Mouth _mouth;

        protected virtual void Awake()
        {
            _player = FindObjectOfType<Player>();
            _mouth = FindObjectOfType<Mouth>();

        }

        private void OnEnable()
        {
            _player.CollisionWithTrigger += Reached;

        }
        private void OnDisable()
        {
            _player.CollisionWithTrigger -= Reached;

        }

        protected abstract void Reached(Collider other);
    }