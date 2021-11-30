
using UnityEngine;
using UnityEngine.Events;

namespace Human
{
    public class Human : Eateble
    {
        private int _count;
        public event UnityAction<int> CountChanged;
        public event UnityAction GameOver;
        

        protected override void Reached(Collider other)
        {
        }

        protected override void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Human _) ) return;
            
            if (other.GetComponent<MeshRenderer>().material.color ==
                _player.GetComponent<MeshRenderer>().material.color || _feverEnable)
            {
                base.OnEat(other);
                _count++;
                CountChanged?.Invoke(_count);
                
            }
                
            else
            {
                GameOver?.Invoke();

            }

        }
        
    }
}