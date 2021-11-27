
using UnityEngine;

namespace Human
{
    public class Human : Eateble
    {
        

        protected override void Reached(Collider other)
        {
            if (!other.TryGetComponent(out Human _) ) return;
            if (other.GetComponent<MeshRenderer>().material.color == _player.GetComponent<MeshRenderer>().material.color )
                base.Reached(other);
            else
            {
                Debug.Log("dead");
                
            }

        }
    }
}