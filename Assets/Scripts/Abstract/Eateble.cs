    using UnityEngine;

    public abstract class Eateble : Collectables
    {
        
        private void OnEnable()
        {
            _mouth.eat += OnEat;
            
        }
        private void OnDisable()
        {
            _mouth.eat -= OnEat;
            
        }

        protected virtual void OnEat(Collider other)
        {
            if (!other.TryGetComponent(out Eateble eat)) return;
            eat.gameObject.SetActive(false);
           
        }

    }
