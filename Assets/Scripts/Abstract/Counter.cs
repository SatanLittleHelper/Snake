using DefaultNamespace.Player;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Abstract
{
    public abstract class Counter : MonoBehaviour
    {
        protected Mouth _mouth;
        public event UnityAction<int> CountChanged;

        private int _count { get; set; }

        protected virtual void Awake()
        {
            _mouth = FindObjectOfType<Mouth>();
            
        }
   
        protected void Eat(Collider other)
        {
            _count++;
            CountChanged?.Invoke(_count);
            
        }

    }
}