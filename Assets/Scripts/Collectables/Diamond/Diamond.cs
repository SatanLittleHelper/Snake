
using UnityEngine;

namespace Diamond
{
    public class Diamond : Collectables
    {
        protected override void Reached(Collider other)
        {
            if (other.TryGetComponent(out Diamond diamond))
            {
                diamond.gameObject.SetActive(false);
            }   
            //TODO: implement here diamond getting
            return;
        }
        
    }
}