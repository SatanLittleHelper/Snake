using DefaultNamespace;
using DefaultNamespace.Player;
using UnityEngine;


public abstract class Collectables : MonoBehaviour
    {
        protected Player _player;
        protected Mouth _mouth;
        protected Fever _fever;
        protected bool _feverEnable;


        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _mouth = FindObjectOfType<Mouth>();
            _fever = FindObjectOfType<Fever>();

        }

        private void OnEnable()
        {
            _player.CollisionWithTrigger += Reached;
            _fever.FeverStarted += OnFever;

        }
        private void OnDisable()
        {
            _player.CollisionWithTrigger -= Reached;
            _fever.FeverStarted -= OnFever;

        }

        protected abstract void Reached(Collider other);

        private void OnFever(bool state)
        {
            _feverEnable = state;
        }
    }