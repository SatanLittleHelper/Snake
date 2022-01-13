using System;
using DefaultNamespace.Abstract;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameOverHandler : Handler
    {
        private Barrier.Barrier _barrier;

        public event Action GameOver;

        protected override void onSpawnEnded()
        {
            base.onSpawnEnded();
            
            _barrier = FindObjectOfType<Barrier.Barrier>();
            _barrier.GameOver += OnGameOver;
            _human.GameOver += OnGameOver;

        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            _human.GameOver -= OnGameOver;
            _barrier.GameOver -= OnGameOver;
            
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            GameOver?.Invoke();

        }
    }
}