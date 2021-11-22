
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private int _roadFragmentCount;
    [SerializeField] private Road _roadPrefab;
    // private Road _firstRoadElement;
    private List<Road> _allRoadElements;

    public List<Road> AllRoads => _allRoadElements;

    public event UnityAction OnRoadSpawnEnded;

    private void Start()
    {
        // _firstRoadElement = FindObjectOfType<Road>();
        _allRoadElements = new List<Road>();
        SpawnAllRoadsElement(_roadFragmentCount);
    }
    

    private void SpawnAllRoadsElement(int count)
    {
        var offset = _roadPrefab.GetComponent<MeshRenderer>().bounds.size.z;
        var roadElement = _roadPrefab;
        var position = roadElement.transform.position;
        
        for (int i = 0; i < count; i++)
        {
            position = new Vector3(position.x, position.y, position.z + offset);
            roadElement = Instantiate(roadElement, position, Quaternion.identity, transform);
            _allRoadElements.Add(roadElement);
        }
        OnRoadSpawnEnded?.Invoke();
        
    }
}
