using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class FeverProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        private Fever _fever;


        private void Awake()
        {
            _fever = FindObjectOfType<Fever>();
            
        }

        private void OnEnable()
        {
            _fever.CountToFeverChanged += OnCountToFeverChanged;
            
        }

        

        private void OnDisable()
        {
            _fever.CountToFeverChanged -= OnCountToFeverChanged;
        }
        
        private void OnCountToFeverChanged(int toFever)
        {
            float progress = 0f;
            
            if (toFever != 0) progress = (float)toFever / _fever.ToFeverStart;
            
            _progressBar.fillAmount = progress;
            
        }
    }
}