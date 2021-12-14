using System.Collections;
using Diamond;
using Human;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Fever : MonoBehaviour
    {
        [SerializeField] private int _countToStart;
        [SerializeField] private FeverPanel _feverPanel;
        private HumanCounter _humanCounter;
        private DiamondCounter _diamondCounter;
        private HumanSpawner _spawner;
        private int _count;
        private bool _feverEnable;

        public event UnityAction<bool> FeverStarted;
        public event UnityAction FeverWillEndSoon;
        public event UnityAction<float> CountToFeverChanged;

        public int ToFeverStart => _countToStart;

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
            
        }

        private void onSpawnEnded()
        {
            _humanCounter = FindObjectOfType<HumanCounter>();
            _diamondCounter = FindObjectOfType<DiamondCounter>();
            
            _humanCounter.CountChanged += OnHumanCountChanged;
            _diamondCounter.CountChanged += OnDiamondCountChanged;

        }

        private void OnHumanCountChanged(int arg0)
        {
            if (_feverEnable) return;
            
            _count = 0;
            CountToFeverChanged?.Invoke(_count);
            
        }

        private void OnDiamondCountChanged(int arg0)
        {
            if (_feverEnable) return;
            
            _count++;
            CountToFeverChanged?.Invoke(_count);

            if (_count != _countToStart) return;
            
            StartCoroutine(InFever());
            StartCoroutine(ChangeCountSmoothly());

        }

        private IEnumerator InFever()
        {
            ChangeFeverState(true);

            yield return new WaitForSeconds(4f);
            
            FeverWillEndSoon?.Invoke();
            
            yield return new WaitForSeconds(1f);
            
            ChangeFeverState(false);

        }

        private void ChangeFeverState(bool state)
        {
            FeverStarted?.Invoke(state);
            _feverEnable = state;
            _feverPanel.gameObject.SetActive(state);
            
        }

        private IEnumerator ChangeCountSmoothly()
        {
            float count = _count;
            
            while (count > 0)
            {
                count -= Time.deltaTime;
                CountToFeverChanged?.Invoke(count);

                yield return null;
                
            }
            _count = 0;

        }
        
    }
    
}