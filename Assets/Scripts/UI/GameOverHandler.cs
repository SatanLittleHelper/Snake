using DefaultNamespace.Abstract;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class GameOverHandler : Handler
    {
        private Barrier.Barrier _barrier;

        public event UnityAction GameOver;

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
            GameOver?.Invoke();
            Ads.instance.ShowAds();

        }
    }
}