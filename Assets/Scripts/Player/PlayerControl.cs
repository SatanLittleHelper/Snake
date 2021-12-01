using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Coroutine _moveRoutine;
    private float _validPositionX = 3.9f;
    private Fever _fever;
    private bool _feverEnabled;
    
    public event UnityAction PlayerMove;

    private void Awake()
    {
        _fever = FindObjectOfType<Fever>();
        
    }

    private void OnEnable()
    {
        _fever.FeverStarted += OnFever;
        _fever.FeverWillEndSoon += OnFeverWillEndSoon;
        
    }

    private void OnDisable()
    {
        _fever.FeverStarted -= OnFever;
        _fever.FeverWillEndSoon -= OnFeverWillEndSoon;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition);
            
        }
        
    }
    
    private void OnFeverWillEndSoon()
    {
        _feverEnabled = false;
        
    }
    
    private void OnFever(bool arg0)
    {
        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);
        
        _moveRoutine = StartCoroutine(ChangePlayerPositionRoutine(Vector3.zero));
        _feverEnabled = arg0;
        
    }
    
    private void Move(Vector3 position)
    {
        if (Camera.main is null) return;
        
        var ray = Physics.RaycastAll(Camera.main.ScreenPointToRay(position));

        if (ray.Length <= 0) return;
       
        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);
            
        _moveRoutine = StartCoroutine(ChangePlayerPositionRoutine(ray[0].point));

    }
    
    private IEnumerator ChangePlayerPositionRoutine(Vector3 target)
    {
        var currentPosition = _player.transform.position;
        var targetPosition = GetValidTargetPosition(target);
        targetPosition = new Vector3(targetPosition.x, currentPosition.y, currentPosition.z);
        
        if (_feverEnabled) 
            targetPosition = new Vector3(0f, currentPosition.y, currentPosition.z);
       
        while (Math.Abs(_player.transform.position.x - targetPosition.x) > 0)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, targetPosition, _player.Sensitivity * Time.deltaTime);
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
