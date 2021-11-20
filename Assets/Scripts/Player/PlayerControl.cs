
using System.Collections;
using UnityEngine;

[RequireComponent(typeof( Player))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    private Coroutine _moveRoutine;

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
        
        while (_player.transform.position != targetPosition)
        {
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, targetPosition, _player.Speed * Time.deltaTime);
            yield return null;
           
            
        }

    }
    
}
