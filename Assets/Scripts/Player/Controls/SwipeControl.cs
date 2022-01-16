using System;
using UnityEngine;

public class SwipeControl : Control
{
    private Vector3 _startMousePosition;

    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0)) _startMousePosition = GetPositionInGameBoard(Input.mousePosition);

        base.Update();

    }

    protected override Vector3 GetTargetPosition(Vector3 position)
    {
        var defaultPosition = _player.transform.position;
        var dir = GetDirection(GetPositionInGameBoard(position));
        
        return GetValidTargetPosition(defaultPosition + dir);

    }

    private Vector3 GetDirection(Vector3 target)
    {
        if (Math.Abs(_startMousePosition.x - target.x) < 0) return Vector3.zero;
        
        return Math.Abs(_startMousePosition.x - target.x) > 0.2f ? 
            new Vector3((_startMousePosition.x - target.x) * Math.Abs(_startMousePosition.x - target.x) / 8  * -1, 0, 0) : Vector3.zero;
        
    }

}
