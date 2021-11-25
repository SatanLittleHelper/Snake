
    using System;
    using UnityEngine;

    public class Checkpoint : MonoBehaviour
    {
        [SerializeField]private Player _player;
        private String _checkpointTag = "Checkpoint";

        private void OnEnable()
        {
            _player.CollisionWithTriger += CheckpointReached;
        }
        private void OnDisable()
        {
            _player.CollisionWithTriger -= CheckpointReached;
        }

        private void CheckpointReached(Collider other)
        {
            if (!other.CompareTag(_checkpointTag))
                 Debug.Log("CheckpointReached");
            //TODO: Implement here checkpointReach
        }
    }
