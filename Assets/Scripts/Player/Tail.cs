
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tail : MonoBehaviour
    {
        [SerializeField] private TailElement[] _tailElements;
        [SerializeField] private Head _head;
        [SerializeField] private PlayerControl _control;
        private Mover _mover;
        private List<Coroutine> _allMoveCoroutines;

        private void Awake()
        {
            _mover = FindObjectOfType<Mover>();
            _allMoveCoroutines = new List<Coroutine>();
        }
        

        private void OnEnable()
        {
            _control.OnPlayerMove += PlayerMoving;
            _mover.OnMoving += PlayerMoving;

            
        } 
        private void OnDisable()
        {
            _control.OnPlayerMove -= PlayerMoving;
            _mover.OnMoving -= PlayerMoving;

            
        }

        private void FixedUpdate()
        {
            ChangeTailPosition();
        }

        private void PlayerMoving()
        {
            // ChangeTailPosition();
        }
        private void ChangeTailPosition()
        {
            
            var targetPosition = _head.transform.position;
            foreach (var tail in _tailElements)
            {
                if ((targetPosition - tail.transform.position).sqrMagnitude >
                    tail.GetComponent<MeshRenderer>().bounds.size.z / 2)
                {
                    (tail.transform.position, targetPosition) = (targetPosition, tail.transform.position);

                }
                
                else
                {
                    break;
                }
            }
        }

    }
