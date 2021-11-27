   
 using System;
 using UnityEngine;

 public class TailElement : MonoBehaviour
 {
     private String _checkpoin = "Checkpoint";
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(_checkpoin))
            {
                GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
            }
        }
    }