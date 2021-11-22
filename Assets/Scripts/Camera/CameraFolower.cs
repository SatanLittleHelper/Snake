using UnityEngine;


    public class CameraFolower : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void FixedUpdate()
        {
            var cameraPostion = _camera.transform.position;
            _camera.transform.position = new Vector3(cameraPostion.x, cameraPostion.y, _player.transform.position.z - 10f);
            //TODO: тут слишком дергано надо переписать завтра на movetowards
        }
    }
