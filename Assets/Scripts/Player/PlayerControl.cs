using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Coroutine _moveRoutine;
    private const float _validPositionX = 3.9f;
    private Fever _fever;
    
    public event UnityAction PlayerMove;

    private void Awake()
    {
        _fever = FindObjectOfType<Fever>();
        
    }

    private void Update()
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

    private Vector3 GetTargetPosition(Vector3 position)
    {
        var defaultPosition = _player.transform.position;
        if (Camera.main is null) return defaultPosition;
        
        var ray = Physics.RaycastAll(Camera.main.ScreenPointToRay(position));

        return ray.Length == 0 ? defaultPosition : GetValidTargetPosition(ray[0].point);
    }
    
    private IEnumerator ChangePlayerPositionRoutine(Vector3 target)
    {
        var currentPosition = _player.transform.position;
        target = new Vector3(target.x, currentPosition.y, currentPosition.z);
       
        while (Math.Abs(_player.transform.position.x - target.x) > 0)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, target, _player.Sensitivity * Time.deltaTime);
            PlayerMove?.Invoke();
            yield return null;
            
        }

    }

    private Vector3 GetValidTargetPosition(Vector3 targetPosition)
    {
        if (targetPosition.x > _validPositionX)
            targetPosition.x = _validPositionX;
        
        if (targetPosition.x < -_validPositionX)
            targetPosition.x = -_validPositionX;
        
        return targetPosition;

    }

}
