using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControlV2 : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Coroutine _moveRoutine;
    private Vector3 _startMousePosition;
    private const float _validPositionX = 3.9f;
    private Fever _fever;
    
    public event UnityAction PlayerMove;

    private void Awake()
    {
        _fever = FindObjectOfType<Fever>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePosition = GetPositionInGameBoard(Input.mousePosition);

        }

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
        
        var dir = GetDirection(GetPositionInGameBoard(Input.mousePosition));
        Debug.Log(dir);
        defaultPosition += dir;
        defaultPosition = GetValidTargetPosition(defaultPosition);
        return defaultPosition;

    }

    private Vector3 GetPositionInGameBoard(Vector3 mousePosition)
    {
        var ray = Physics.RaycastAll(Camera.main.ScreenPointToRay(mousePosition));
        return ray.Length == 0 ? Vector3.zero : ray[0].point;


    }

    private Vector3 GetDirection(Vector3 target)
    {
        if (Math.Abs(_startMousePosition.x - target.x) < 0) return Vector3.zero;
        if (Math.Abs(_startMousePosition.x - target.x) > 1.5f) return new Vector3((_startMousePosition.x - target.x) * -1, 0, 0);
        if (Math.Abs(_startMousePosition.x - target.x) > 0.3f) return new Vector3((_startMousePosition.x - target.x) / 8 * -1, 0, 0);

        return Vector3.zero;
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
