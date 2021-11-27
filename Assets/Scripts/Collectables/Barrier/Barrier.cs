
using UnityEngine;

namespace Barrier
{
    public class Barrier : Collectables
    {
       
        protected override void Reached(Collider other)
        {
            
            if(other.TryGetComponent(out Barrier barrier))
            //TODO implemen here dead
            return;
        }
    }
}