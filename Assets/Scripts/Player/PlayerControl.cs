
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Coroutine _moveRoutine;
    private Vector3 _lastvalidDirection = Vector3.one;
    private String _borderTag = "Border";
    private float _validPositionX = 3.7f;
    
    public event UnityAction PlayerMove;



    private void OnEnable()
    {
        _player.CollisionWithTrigger += CollisionWithTrigger;
    }

    private void OnDisable()
    {
        _player.CollisionWithTrigger -= CollisionWithTrigger;

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
        if (Camera.main is null) return;
        var ray = Physics.RaycastAll(Camera.main.ScreenPointToRay(position));

        if (ray.Length <= 0) return;
       
        if (_moveRoutine != null)
        {
            StopCoroutine(_moveRoutine);
        }
            
        _moveRoutine = StartCoroutine(ChangePlayerPositionRoutine(ray[0].point));

    }
    private IEnumerator ChangePlayerPositionRoutine(Vector3 target)
    {
        var currentPosition = _player.transform.position;
        var targetPosition = new Vector3(target.x, currentPosition.y, currentPosition.z);
        _player.Direction = GetDirrection(targetPosition, currentPosition);
      
        while (Math.Abs(_player.transform.position.x - targetPosition.x) > 0)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, targetPosition, _player.Sensitivity * Time.deltaTime);
            PlayerMove?.Invoke();
            yield return null;
            
        }

    }

    private Vector3 GetDirrection(Vector3 targetPosition, Vector3 currentPosition)
    {
        var heading = targetPosition - currentPosition;
        var distance = heading.magnitude;
        var direction = heading / distance;
        
        if (float.IsNaN(direction.x) || float.IsNaN(direction.y) || float.IsNaN(direction.z))
        {
            return _lastvalidDirection;
        }

        _lastvalidDirection = direction;
        return direction;
    }

    private void CollisionWithTrigger(Collider other)
    {
        if(!other.CompareTag(_borderTag))
            return;
        var playerPosition = _player.transform.position;
        playerPosition.x = _validPositionX * _player.Direction.x;
        //TODO: it's working with bug
        //some times snake jumping to other edge, because i use *_player.Direction
        _player.transform.position = playerPosition;
        
        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);
    }

}
