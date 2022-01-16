using UnityEngine;
using UnityEngine.Advertisements;


    public class AdsHandler : MonoBehaviour, IUnityAdsShowListener
    {
        public static AdsHandler instance;

        private void Awake()
        {
            instance = this;
            
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Debug.Log("start");
            Time.timeScale = 0;
            
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Time.timeScale = 1;
            
        }
        
    }
