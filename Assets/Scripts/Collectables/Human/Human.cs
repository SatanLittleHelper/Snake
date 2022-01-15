using UnityEngine;
using UnityEngine.Events;

namespace Human
{
    public class Human : Eateble
    {
        public event UnityAction GameOver;

        protected override void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Human _) ) return;
            
            if (other.GetComponent<MeshRenderer>().material.color ==
                _player.GetComponent<MeshRenderer>().material.color || _player.FeverEnable)
                base.OnEat(other);
                
            else
            {
                GameOver?.Invoke();

            }

        }
        protected override void Reached(Collider other)
        {
            
        }
        
    }
    
}