
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class Eateble : Collectables
    {
        private int _count;
        public event UnityAction<int> CountChanged;
        protected override void Reached(Collider other)
        {
            if (!other.TryGetComponent(out Eateble eat)) return;
            eat.gameObject.SetActive(false);
            _count++;
            CountChanged?.Invoke(_count);
        }


    }
