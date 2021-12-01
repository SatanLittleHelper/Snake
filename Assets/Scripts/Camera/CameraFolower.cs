using UnityEngine;

    public class CameraFolower : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField]private float _distance = 17f;
        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            
        }

        private void LateUpdate()
        {
            var cameraPostion = _camera.transform.position;
            var targetPosition =
                new Vector3(cameraPostion.x, cameraPostion.y, _player.transform.position.z - _distance);
            _camera.transform.position = targetPosition;

        }
    }
