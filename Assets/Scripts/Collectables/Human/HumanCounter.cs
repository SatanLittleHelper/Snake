using DefaultNamespace.Abstract;
using UnityEngine;

namespace Human
{
    public class HumanCounter : Counter
    {
        private Human _human;
        private HumanSpawner _humanSpawner;

        private bool _gameOver;
        private void OnEnable()
        {
            _mouth.EatHuman += OnEatHuman;
            _humanSpawner.SpawnEnded += OnSpawnEnded;

        }

        private void OnDisable()
        {
            _mouth.EatHuman -= OnEatHuman;
            _humanSpawner.SpawnEnded -= OnSpawnEnded;
            _human.GameOver -= OnGameOver;

        }
        
        private void OnSpawnEnded()
        {
            _human = FindObjectOfType<Human>();
            _human.GameOver += OnGameOver;
            
        }

        protected override void Awake()
        {
            base.Awake();
            _humanSpawner = FindObjectOfType<HumanSpawner>();

        }

        private void OnGameOver()
        {
            _gameOver = true;
            
        }
        
        private void OnEatHuman(Collider arg0)
        {
            if (_gameOver) return;
            
            Eat(arg0);
            
        }
      
    }
    
}