
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof( Player))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Coroutine _moveRoutine = null;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // var ray = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
           // Debug.Log(ray);

            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Move(Camera.main.ViewportToWorldPoint(Input.mousePosition));
            // Move(ray);
            // Debug.Log(Input.mousePosition.normalized);
        }
    }

    private void Move(Vector3 position)
    {
        Debug.Log(position);
        if (_moveRoutine != null)
        {
            StopCoroutine(_moveRoutine);
        }
            
        _moveRoutine = StartCoroutine(ChangePlayerPositionRoutine(position));
    }
    private IEnumerator ChangePlayerPositionRoutine(Vector3 target)
    {
        var currentPosition = _player.transform.position;
        var targetPosition = new Vector3(target.x, currentPosition.y, currentPosition.z);
        
        while (_player.transform.position != targetPosition)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, targetPosition, _player.Speed * Time.deltaTime);
            yield return null;
           
            
        }

    }
    
}
