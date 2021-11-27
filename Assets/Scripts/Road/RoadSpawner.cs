
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private int _roadFragmentCount;
    [SerializeField] private Road _roadPrefab;
    private List<Road> _allRoadElements;
    private Colors _colors;
    public List<Road> AllRoads => _allRoadElements;
    public event UnityAction RoadSpawnEnded;

    private void Awake()
    {
        _colors = FindObjectOfType<Colors>();
        
    }

    private void Start()
    {
        _allRoadElements = new List<Road>();
        SpawnAllRoadsElement(_roadFragmentCount);
        
        
    }
    
    private void SpawnAllRoadsElement(int count)
    {
        var offset = _roadPrefab.GetComponent<MeshRenderer>().bounds.size.z;
        var roadElement = _roadPrefab;
        var position = roadElement.transform.position;
        Material lastColor = null;
        
        for (int i = 0; i < count; i++)
        {
            
            position = new Vector3(position.x, position.y, position.z + offset);
            roadElement = Instantiate(roadElement, position, Quaternion.identity, transform);
            var checkpoint =  roadElement.GetComponentInChildren<Checkpoint>();
            lastColor = _colors.GetRandomColorWithout(lastColor);
            checkpoint.GetComponent<MeshRenderer>().material = lastColor;
           
            _allRoadElements.Add(roadElement);
            
        }
        RoadSpawnEnded?.Invoke();
        
    }
}
