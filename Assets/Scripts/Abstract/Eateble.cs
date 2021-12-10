    using UnityEngine;

    public abstract class Eateble : Collectables
    {
        
        private void OnEnable()
        {
            _mouth.Eat += OnEat;
            
        }
        private void OnDisable()
        {
            _mouth.Eat -= OnEat;
            
        }

        protected virtual void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Eateble eat)) return;
            eat.gameObject.SetActive(false);
           
        }

    }
