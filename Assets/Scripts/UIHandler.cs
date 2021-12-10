using Diamond;
using Human;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _diamondCount;
        [SerializeField] private TMP_Text _humanCount;
        [SerializeField] private RectTransform _gameOverPanel;

        private HumanSpawner _spawner;
        private Human.Human _human;
        private HumanCounter _humanCounter;
        private DiamondCounter _diamondCounter;
        private Diamond.Diamond _diamond;
        private Barrier.Barrier _barrier;

        private void Awake()
        {
            _spawner = FindObjectOfType<HumanSpawner>();
            
        }

        private void OnEnable()
        {
            _spawner.SpawnEnded += onSpawnEnded;
            
        }

        private void OnDisable()
        {
            _spawner.SpawnEnded -= onSpawnEnded;
            _humanCounter.CountChanged -= OnHumanCountChanged;
            _diamondCounter.CountChanged -= OnDiamondCountChanged;
            _barrier.GameOver -= OnGameOver;
            _human.GameOver -= OnGameOver;
            //todo: need implement UI 
        }

        private void onSpawnEnded()
        {
            _human = FindObjectOfType<Human.Human>();
            _diamond = FindObjectOfType<Diamond.Diamond>();
            _barrier = FindObjectOfType<Barrier.Barrier>();
            _humanCounter = FindObjectOfType<HumanCounter>();
            _diamondCounter = FindObjectOfType<DiamondCounter>();
            
            _humanCounter.CountChanged += OnHumanCountChanged;
            _diamondCounter.CountChanged += OnDiamondCountChanged;
            _barrier.GameOver += OnGameOver;
            _human.GameOver += OnGameOver;

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
            Time.timeScale = 0;
            _gameOverPanel.gameObject.SetActive(true);
            
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            
        }
        
    }
    
}