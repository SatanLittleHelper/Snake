
using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private int _roadFragmentCount;
    [SerializeField] private Road _roadPrefab;
    private Road _firstRoadElement;
    
    public event UnityAction OnSpawnEnded;

    private void Start()
    {
        _firstRoadElement = FindObjectOfType<Road>();
        SpawnAllRoadsElement(_roadFragmentCount);
    }
    

    private void SpawnAllRoadsElement(int count)
    {
        var offset = _firstRoadElement.GetComponent<MeshRenderer>().bounds.size.z;
        var roadElement = _firstRoadElement;
        var position = roadElement.transform.position;
        
        for (int i = 0; i < count; i++)
        {
            position = new Vector3(position.x, position.y, position.z + offset);
            roadElement = Instantiate(roadElement, position, Quaternion.identity, transform);
        }
        OnSpawnEnded?.Invoke();
        
    }
}
