using DefaultNamespace.Road;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    private DestroyPoint _destroyPoint;

    public event UnityAction NeedToSwap; 


    public Vector3 Size { get; private set; }

    private void Awake()
    {
        Size = GetComponent<MeshRenderer>().bounds.size;
        _destroyPoint = GetComponentInChildren<DestroyPoint>();

    }

    private void OnEnable()
    {
        _destroyPoint.DestroyPointReached += OnDestroyPointReached;
        
    }

    private void OnDisable()
    {
        _destroyPoint.DestroyPointReached -= OnDestroyPointReached;
        
    }

    private void OnDestroyPointReached()
    {
        NeedToSwap?.Invoke();
        
    }
    
}
