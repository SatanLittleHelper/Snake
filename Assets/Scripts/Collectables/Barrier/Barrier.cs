using UnityEngine;
using UnityEngine.Events;

namespace Barrier
{
    public class Barrier : Collectables
    { 
        public event UnityAction GameOver;
       
        protected override void Reached(Collider other)
        {
            if (!other.TryGetComponent(out Barrier _)) return;
            
            if (_player.FeverEnable)
                other.gameObject.SetActive(false);
            
            else
            {
                GameOver?.Invoke();

            }

        }
        
    }
    
}