
    using System;
    using UnityEngine;

    public class Checkpoint : MonoBehaviour
    {
        private Player _player;
        private String _checkpointTag;


        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _checkpointTag  = "Checkpoint";
        }

        private void OnEnable()
        {
            _player.CollisionWithTrigger += OnCollisionWhithTrigger;
        }
        private void OnDisable()
        {
            _player.CollisionWithTrigger -= OnCollisionWhithTrigger;
        }

        private void OnCollisionWhithTrigger(Collider other)
        {
            if (other.CompareTag(_checkpointTag))
                CheckpointReached(other);           
        }

        private void CheckpointReached(Collider other)
        {
            _player.GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
        }
    }
