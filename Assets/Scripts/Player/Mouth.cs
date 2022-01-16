using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Player
{
    public class Mouth : MonoBehaviour
    {
        public event UnityAction<Collider> Eat;
        public event UnityAction<Collider> EatDiamond;
        
        public event UnityAction<Collider> EatHuman;


        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Eateble _)) return;
            Eat?.Invoke(other);
            
            if (other.TryGetComponent(out Diamond.Diamond _)) EatDiamond?.Invoke(other);
            if (other.TryGetComponent(out Human.Human _)) EatHuman?.Invoke(other);

        }
        
    }
    
}