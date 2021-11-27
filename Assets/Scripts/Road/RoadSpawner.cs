
using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

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
        var colors = _colors.AllColors;
        
        
        for (int i = 0; i < count; i++)
        {
            position = new Vector3(position.x, position.y, position.z + offset);
            roadElement = Instantiate(roadElement, position, Quaternion.identity, transform);
            var checkpint =  roadElement.GetComponentInChildren<Checkpoint>();
            checkpint.GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
           
            _allRoadElements.Add(roadElement);
            
        }
        RoadSpawnEnded?.Invoke();
        
    }
}
