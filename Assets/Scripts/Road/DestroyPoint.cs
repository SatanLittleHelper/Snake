using System;
using UnityEngine;

namespace DefaultNamespace.Road
{
    public class DestroyPoint : MonoBehaviour
    {
        public event Action DestroyPointReached; 
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out global::Player _))
                DestroyPointReached?.Invoke();
        }
    }
}