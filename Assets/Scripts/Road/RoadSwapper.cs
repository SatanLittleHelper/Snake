using System.Collections.Generic;
using UnityEngine;


    public class RoadSwapper : MonoBehaviour
    {
        private RoadSpawner _roadSpawner;
        private List<Road> _allRoads;

        private void Awake()
        {
            _roadSpawner = FindObjectOfType<RoadSpawner>();
            
        }

        private void OnEnable()
        {
            _roadSpawner.RoadSpawnEnded += OnRoadSpawnEnded;
            
        }
        
        private void OnDisable()
        {
            _roadSpawner.RoadSpawnEnded -= OnRoadSpawnEnded;
            AllROadsRemoveListener(_allRoads);
        }

        private void OnRoadSpawnEnded()
        {
            _allRoads = _roadSpawner.AllRoads;
            AllRoadsAddListener(_allRoads);
            
        }

        private void AllRoadsAddListener(List<Road> roads)
        {
            foreach (var road in roads)
            {
                road.NeedToSwap += OnNeedToSwap;
                
            }
            
        }

        private void AllROadsRemoveListener(List<Road> roads)
        {
            foreach (var road in roads)
            {
                road.NeedToSwap -= OnNeedToSwap;
                
            }
            
        }

       

        private void OnNeedToSwap()
        {
            var road = _allRoads[0];
            road.transform.position = new Vector3(road.transform.position.x,road.transform.position.y,
                _allRoads[_allRoads.Count - 1].transform.position.z + road.Size.z);
            _allRoads.RemoveAt(0);
            _allRoads.Add(road);
            _roadSpawner.AllRoads = _allRoads;
            

        }
    }
