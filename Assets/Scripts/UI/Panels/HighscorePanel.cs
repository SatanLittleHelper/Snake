using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class HighscorePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _curentScoreText;
        [SerializeField] private TMP_Text _highscoreText;
        [SerializeField] private TMP_Text _newHighscore;
        private string _highscoreTitle;
        private string _curentScoreTitle;
        
        private HighScore _highScore;

        private void Awake()
        {
            SaveDefaultTitle();
            
        }

        private void OnEnable()
        {
            _highScore = FindObjectOfType<HighScore>();
            ShowHighscore();
            
        }

        private void SaveDefaultTitle()
        {
            _highscoreTitle = _highscoreText.text;
            _curentScoreTitle = _curentScoreText.text;

        }

        private void ShowHighscore()
        {
            _curentScoreText.text = _curentScoreTitle + _highScore.CurentScore;
            _highscoreText.text = _highscoreTitle + _highScore.Highscore;

            if (!_highScore.HighscoreReached) return;
            
            _highscoreText.gameObject.SetActive(false);
            _newHighscore.gameObject.SetActive(true);


        }
        
    }
    
}