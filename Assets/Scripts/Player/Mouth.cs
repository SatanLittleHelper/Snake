using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Player
{
    public class Mouth : MonoBehaviour
    {
        public event UnityAction<Collider> eat;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Eateble _))
                eat?.Invoke(other);
        }
    }
}