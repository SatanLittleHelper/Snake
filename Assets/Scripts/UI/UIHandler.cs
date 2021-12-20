using DefaultNamespace.Abstract;
using Diamond;
using Human;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UIHandler : Handler
    {
        [SerializeField] private TMP_Text _diamondCount;
        [SerializeField] private TMP_Text _humanCount;
        [SerializeField] private GameOverPanel _gameOverPanel;

        private HumanCounter _humanCounter;
        private DiamondCounter _diamondCounter;
        private GameOverHandler _gameOverHandler;


        protected override void OnDisable()
        {
            base.OnDisable();
            
            _humanCounter.CountChanged -= OnHumanCountChanged;
            _diamondCounter.CountChanged -= OnDiamondCountChanged;
            _gameOverHandler.GameOver -= OnGameOver;

        }

        protected override void onSpawnEnded()
        {
            base.onSpawnEnded();
            
            _humanCounter = FindObjectOfType<HumanCounter>();
            _diamondCounter = FindObjectOfType<DiamondCounter>();
            _gameOverHandler = FindObjectOfType<GameOverHandler>();
            
            _humanCounter.CountChanged += OnHumanCountChanged;
            _diamondCounter.CountChanged += OnDiamondCountChanged;
            _gameOverHandler.GameOver += OnGameOver;

        }

        private void OnHumanCountChanged(int count)
        {
            _humanCount.text = count.ToString();
            
        }

        private void OnDiamondCountChanged(int count)
        {
            _diamondCount.text = count.ToString();
            
        }

        private void OnGameOver()
        {
            _gameOverPanel.gameObject.SetActive(true);
            
        }

        public void RestartGame()
        {
            Ads.instance.ShowAds();

            SceneManager.LoadScene(sceneBuildIndex: 0);
            
        }
        
    }
    
}