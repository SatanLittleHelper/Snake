using UnityEngine;


    public abstract class PanelsHelper : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        protected virtual void OnEnable()
        {
            Time.timeScale = 0;
            _audioSource.Pause();
            
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _audioSource.UnPause();
            
        }
        
        public virtual void PlayButtonPressed()
        {
            gameObject.SetActive(false);
            
        }

    }
