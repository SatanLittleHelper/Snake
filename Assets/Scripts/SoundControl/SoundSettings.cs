using UnityEngine;
using UnityEngine.Audio;


public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        private bool _soundState;

        private void Awake()
        {
           _soundState = LoadSettings();
           ApplyUserSettings();

        }

        public void ApplyUserSettings()
        {
            ChangeSnapshot(_soundState ? "Play" : "Off");
            
        }
        
        public bool ChangeSoundState()
        {
            if (_soundState)
            {
                ChangeSnapshot("Off");
                _soundState = false;
                
            }
            else
            {
                ChangeSnapshot("Play");
                _soundState = true;
                
            }
            SaveSettings();
            
            return _soundState;
            
        }

        private void ChangeSnapshot(string SnapshotName)
        {
            var snapshot = _audioMixer.FindSnapshot(SnapshotName);
            snapshot.TransitionTo(0);

        }
        
        private void SaveSettings()
        {
            PlayerPrefs.SetString("SoundState", _soundState.ToString());
            
        }

        public bool LoadSettings()
        {
            var str = PlayerPrefs.GetString("SoundState", "True");

            return  str == "True";
            
        }
        
    }
