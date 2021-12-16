using DefaultNamespace.Abstract;
using UnityEngine;

namespace Diamond
{
    public class DiamondCounter : Counter
    {
        
        private void OnEnable()
        {
            _mouth.EatDiamond += OnEatDiamond;
            _score = 10;

        }

        private void OnDisable()
        {
            _mouth.EatDiamond -= OnEatDiamond;

            
        }

        private void OnEatDiamond(Collider arg0)
        {
            Eat(arg0);

        }
       
        
    }
}