using System.Collections;
using Human;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Fever : MonoBehaviour

    {
        [SerializeField] private int _countToStart;
        private Human.Human _human;
        private Diamond.Diamond _diamond;
        private HumanSpawner _spawner;
        private int _count;
        private bool _feverEnable;

        public event UnityAction<bool> FeverStarted;
        public event UnityAction FeverWillEndSoon; 


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

            _human.CountChanged -= OnHumanCountChanged;
            _diamond.CountChanged -= OnDiamondCountChanged;
        }


        private void onSpawnEnded()
        {
            _human = FindObjectOfType<Human.Human>();
            _diamond = FindObjectOfType<Diamond.Diamond>();
            
            _human.CountChanged += OnHumanCountChanged;
            _diamond.CountChanged += OnDiamondCountChanged;

        }

        private void OnHumanCountChanged(int arg0)
        {
            _count = 0;
        }

        private void OnDiamondCountChanged(int arg0)
        {
            if (_feverEnable) return;
            _count++;
            if (_count != _countToStart) return;
            StartCoroutine(InFever());
            _count = 0;

        }

        private IEnumerator InFever()
        {
            FeverStarted?.Invoke(true);
            _feverEnable = true;

            yield return new WaitForSeconds(4f);
            FeverWillEndSoon?.Invoke();
            yield return new WaitForSeconds(1f);
            FeverStarted?.Invoke(false);
            _feverEnable = false;


        }
        
    }
}