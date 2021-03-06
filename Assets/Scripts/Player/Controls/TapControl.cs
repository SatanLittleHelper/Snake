using UnityEngine;

public class TapControl : Control
{
    protected override Vector3 GetTargetPosition(Vector3 position)
    {
        var defaultPosition = _player.transform.position;
        var targetPosition = GetValidTargetPosition(GetPositionInGameBoard(position));
        
        return targetPosition == Vector3.zero ? defaultPosition : targetPosition;
    }
    
    

}
