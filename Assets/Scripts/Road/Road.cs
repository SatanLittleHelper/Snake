using System;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    private Vector3 _size;

    // public delegate Player NeedToSwap(Road element);

    public event UnityAction NeedToSwap; 


    public Vector3 Size => _size;

    private void Start()
    {
        _size = GetComponent<MeshRenderer>().bounds.size;
        
    }

    private void Update()
    {
        if (Camera.main is null) return;
        
        var pos  = Camera.main.ViewportToWorldPoint(Vector3.zero);
        
        if (Math.Abs(pos.z - transform.position.z - 50) > 0.1f) return;
        
        NeedToSwap?.Invoke();
        
    }
    
}
