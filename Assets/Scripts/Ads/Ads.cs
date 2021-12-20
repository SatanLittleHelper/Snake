using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;

public class Ads : MonoBehaviour, IUnityAdsShowListener
    {
        [SerializeField] private bool _testMode = true;
        [SerializeField] private int _probablyShowAds = 30;

        public static Ads instance;

        #region Android 
        
        // private readonly String _gameIDAndroid = "4516327";
        // private static readonly String _videoAndroid = "Interstitial_Android";

        #endregion

        #region iOS

        private readonly String _gameIDiOS = "4516326";
        private static readonly String _videoIOS = "Interstitial_iOS";

        #endregion

        private void Awake()
        {
            instance = this;
            
        }

        private void Start()
        {
            Advertisement.Initialize(_gameIDiOS, _testMode);
            
        }

        public void ShowAds()
        {
            if (!Advertisement.isInitialized) return;
            
            if (Random.Range(0, 100) <= _probablyShowAds)
                Advertisement.Show(_videoIOS, this);

        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Time.timeScale = 1;
            
        }
        
    }