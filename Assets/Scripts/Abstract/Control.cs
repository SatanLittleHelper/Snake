using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;


    public abstract class Control : MonoBehaviour
    {
        [SerializeField] protected Player _player;
        private Coroutine _moveRoutine;
        private const float _validPositionX = 3.9f;
        private Fever _fever;
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
            _fever = FindObjectOfType<Fever>();
            
        }

        protected virtual void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Move(Input.mousePosition);
            
            }
        
        }
        
        private void Move(Vector3 position)
        {
            if (_moveRoutine != null)
            {
                StopCoroutine(_moveRoutine);
                _moveRoutine = null;
            
            }
            _moveRoutine = StartCoroutine(ChangePlayerPositionRoutine(GetTargetPosition(position)));

        }
        
        private IEnumerator ChangePlayerPositionRoutine(Vector3 target)
        {
            var currentPosition = _player.transform.position;
            target = new Vector3(target.x, currentPosition.y, currentPosition.z);
       
            while (Math.Abs(_player.transform.position.x - target.x) > 0)
            {
                _player.transform.position =
                    Vector3.MoveTowards(_player.transform.position, target, _player.Sensitivity * Time.deltaTime);
                yield return null;
            
            }

        }
        
        protected Vector3 GetPositionInGameBoard(Vector3 mousePosition)
        {
            var ray = Physics.RaycastAll(_camera.ScreenPointToRay(mousePosition));
            return ray.Length == 0 ? Vector3.zero : ray[0].point;

        }
        
        protected Vector3 GetValidTargetPosition(Vector3 targetPosition)
        {
            if (targetPosition.x > _validPositionX)
                targetPosition.x = _validPositionX;
        
            if (targetPosition.x < -_validPositionX)
                targetPosition.x = -_validPositionX;
        
            return targetPosition;

        }

        protected abstract Vector3 GetTargetPosition(Vector3 position);

    }
