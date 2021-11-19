
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(PlayerControl))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed => _speed;
    
}
