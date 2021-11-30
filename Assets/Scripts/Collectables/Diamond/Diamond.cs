


using UnityEngine;
using UnityEngine.Events;

namespace Diamond
{
    public class Diamond : Eateble{
        
        private int _count;
        public event UnityAction<int> CountChanged;

        protected override void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Diamond _) ) return;

            base.OnEat(other);
            _count++;
            CountChanged?.Invoke(_count);
        }

        protected override void Reached(Collider other)
        {
        }
    }
}