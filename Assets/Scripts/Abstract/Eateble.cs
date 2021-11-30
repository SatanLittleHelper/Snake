
    using UnityEngine;

    public abstract class Eateble : Collectables
    {
       
        protected override void Reached(Collider other)
        {
            if (!other.TryGetComponent(out Eateble eat)) return;
            eat.gameObject.SetActive(false);
        }


    }
