using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;

public class Ads : MonoBehaviour
    {
        [SerializeField] private bool _testMode = true;
        [SerializeField] private int _probablyShowAds = 30;
        private string _gameID;
        private string _video;

        public static Ads instance;

        #region Android
        
        
        private readonly String _gameIDAndroid = "4516327";
        private static readonly String _videoAndroid = "Interstitial_Android";

        #endregion

        #region iOS

        private readonly String _gameIDiOS = "4516326";
        private static readonly String _videoIOS = "Interstitial_iOS";

        #endregion

        private void Awake()
        {
            instance = this;
            CheckOS();
            
        }

        private void Start()
        {
            Advertisement.Initialize(_gameID, _testMode);
            
        }

        public void ShowAds()
        {
            if (!Advertisement.isInitialized) return;
            
            if (Random.Range(0, 100) <= _probablyShowAds)
                Advertisement.Show(_video, AdsHandler.instance );

        }

        private void CheckOS()
        {
     
            if (SystemInfo.operatingSystem.ToLower().Contains("android"))
            {
                _video = _videoAndroid;
                _gameID = _gameIDAndroid;
                
            }
            
            else if (SystemInfo.operatingSystem.ToLower().Contains("ios"))
            {
                _video = _videoIOS;
                _gameID = _gameIDiOS;
                
            }
            else 
            {
                _gameID = _gameIDiOS;
                _video = _videoIOS;
                
            }
            
            
        }
        
    }