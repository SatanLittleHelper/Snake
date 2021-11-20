
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof( Player))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    private Coroutine _moveRoutine;
    private Vector3 _lastvalidDirection = Vector3.one;


    private void OnEnable()
    {
        _player.Head.OnCollisionWithBorder += CollisionWithBorder;
    }

    private void OnDisable()
    {
        _player.Head.OnCollisionWithBorder -= CollisionWithBorder;

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
      
        while (_player.transform.position != targetPosition)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, targetPosition, _player.Speed * Time.deltaTime);
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

    private void CollisionWithBorder(Collider other)
    {
        var playerPosition = _player.transform.position;
        
        playerPosition.x = other.transform.position.x - (_player.Head.Bounds.size.x * _player.Direction.x);
        _player.transform.position = playerPosition;
        
        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);
    }

}
