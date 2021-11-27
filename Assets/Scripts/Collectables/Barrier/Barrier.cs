
using UnityEngine;

namespace Barrier
{
    public class Barrier : Collectables
    {
       
        protected override void Reached(Collider other)
        {
            
            if(other.TryGetComponent(out Barrier barrier))
                Debug.Log("dead");
            //TODO implemen here dead
            return;
        }
    }
}