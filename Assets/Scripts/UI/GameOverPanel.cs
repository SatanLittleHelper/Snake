using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _curentScoreText;
        [SerializeField] private TMP_Text _highscoreText;
        [SerializeField] private TMP_Text _newHighscore;
        
        private HighScore _highScore;

        private void Awake()
        { 
            _highScore = FindObjectOfType<HighScore>();
            ShowHighscorePanel();

        }

        private void ShowHighscorePanel()
        {
            _curentScoreText.text += _highScore.CurentScore.ToString();
            _highscoreText.text += _highScore.Highscore.ToString();

            if (!_highScore.HighscoreReached) return;
            
            _highscoreText.gameObject.SetActive(false);
            _newHighscore.gameObject.SetActive(true);


        }
        
    }
    
}