using UnityEngine;


    public class CameraFolower : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private Player _player;
        private float _distance = 10f;

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
            //TODO: тут слишком дергано надо переписать завтра на movetowards

        }
    }
