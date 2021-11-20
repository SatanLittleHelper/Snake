
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(PlayerControl))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SnakeHead _head;
    private Vector3 _direction;

    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
    }


    public float Speed => _speed;
    public SnakeHead Head => _head;

}
