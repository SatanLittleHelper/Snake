using UnityEngine;

namespace DefaultNamespace
{
    public class Colors : MonoBehaviour
    {
        [SerializeField] private Material[] _colors;
        public Material[] AllColors => _colors;

        public  Material GetRandomColor()
        {
            return _colors[Random.Range(0, _colors.Length)];
        }
    }
}