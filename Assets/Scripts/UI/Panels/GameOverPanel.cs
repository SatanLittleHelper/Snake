using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameOverPanel : MonoBehaviour
    {
        private HighscorePanel _highscorePanel;

        private void Awake()
        {
            _highscorePanel = FindObjectOfType<HighscorePanel>(true);
             FindObjectOfType<UIPanel>().gameObject.SetActive(false);
            _highscorePanel.gameObject.SetActive(true);
            
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1;
            Ads.instance.ShowAds();
            SceneManager.LoadScene(sceneBuildIndex: 1);
            
        }
        
    }
    
}