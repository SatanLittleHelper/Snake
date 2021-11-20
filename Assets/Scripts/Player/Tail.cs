
    using System;
    using System.Collections;
    using UnityEngine;

    public class Tail : MonoBehaviour
    {
        [SerializeField] private TailElement[] _tailElements;
        [SerializeField] private Head _head;
        [SerializeField] private PlayerControl _control;
        private PlayerMover _mover;

        private void Awake()
        {
            _mover = FindObjectOfType<PlayerMover>();
        }

        private void OnEnable()
        {
            _control.OnPlayerMove += PlayerMoved;
            _mover.OnPlayerMove += PlayerMoved;

            
        } 
        private void OnDisable()
        {
            _control.OnPlayerMove -= PlayerMoved;
            _mover.OnPlayerMove -= PlayerMoved;

            
        }

        private void PlayerMoved()
        {
            ChangeTailPosition();
        }
        private void ChangeTailPosition()
        {
            var targetPosition = _head.transform.position;

            foreach (var tail in _tailElements)
            {
                (tail.transform.position, targetPosition) = (targetPosition, tail.transform.position);

                // tail.transform.position = new Vector3(targetPosition.x, targetPosition.y, tailPosition.z);
            }
        }

        private IEnumerator MoveRoutine(TailElement tail, Vector3 target)
        {
            var currentPosition = tail.transform.position;
            var targetPosition = new Vector3(target.x, currentPosition.y, currentPosition.z);
            while (tail.transform.position != targetPosition)
            {
                tail.transform.position =
                    Vector3.MoveTowards(tail.transform.position, targetPosition, _head.Speed * Time.deltaTime);

                yield return null;
            }
        }
    }
