
using UnityEngine;

namespace Diamond
{
    public class Diamond : Collectables
    {
        protected override void Reached(Collider other)
        {
            if(other.TryGetComponent(out Diamond diamond))
                Debug.Log("Get diamond");
            //TODO: implement here diamond getting
        }
        
    }
}