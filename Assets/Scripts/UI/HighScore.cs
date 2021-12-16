using System;
using Diamond;
using Human;
using UnityEngine;

namespace DefaultNamespace
{
    public class HighScore : MonoBehaviour
    {
        private DiamondCounter _diamondCounter;
        private HumanCounter _humanCounter;
        private GameOverHandler _gameOverHandler;
        private int _curentScore;
        private int _highscore;
        private String _highscorePref = "highscore";
        private bool _highscoreReached;
        

        public int CurentScore => _curentScore;
        public int Highscore => _highscore;
        public bool HighscoreReached => _highscoreReached;


        private void Awake()
        {
            _diamondCounter = FindObjectOfType<DiamondCounter>();
            _humanCounter = FindObjectOfType<HumanCounter>();
            _gameOverHandler = FindObjectOfType<GameOverHandler>();
            LoadHighscore();

        }

        private void OnEnable()
        {
            _diamondCounter.AddScore += OnAddScore;
            _humanCounter.AddScore += OnAddScore;
            _gameOverHandler.GameOver += OnGameOver;

        }

        private void OnDisable()
        {
            _diamondCounter.AddScore -= OnAddScore;
            _humanCounter.AddScore -= OnAddScore;
            _gameOverHandler.GameOver -= OnGameOver;

        }

        private void OnAddScore(int score)
        {
            _curentScore += score;
            CheckHighscore(_curentScore);
            
        }

        private void OnGameOver()
        {
            SaveHighscore();
            
        }

        private void LoadHighscore()
        {
           _highscore = PlayerPrefs.GetInt(_highscorePref, 0);
           Debug.Log($"highscore - {_highscore}");
            
        }

        private void SaveHighscore()
        {
            PlayerPrefs.SetInt(_highscorePref, _highscore);
            
        }

        private void CheckHighscore(int curentScore)
        {
            if (_highscore > curentScore) return;
            _highscoreReached = true;
            _highscore = curentScore;

        }
        
        
    }
    
}