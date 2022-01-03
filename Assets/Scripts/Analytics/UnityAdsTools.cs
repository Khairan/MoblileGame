using System;
using UnityEngine;
using UnityEngine.Advertisements;


namespace Tools
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower
    {
        private const string GameId = "4521141";
        private const string BannerdPlacementId = "Banner_Android";
        private const string RewardPlacementId = "Rewarded_Android";
        private const string InterstitialPlacementId = "Interstitial_Android";

        private Action _callbackSuccessShowVideo;

        private void Start()
        {
            Advertisement.Initialize(GameId, true);
        }
        
        public void ShowBanner()
        {
            Advertisement.Show(BannerdPlacementId);
        }

        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(InterstitialPlacementId);
        }

        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(RewardPlacementId);
        }

        public void OnUnityAdsReady(string placementId)
        {

        }

        public void OnUnityAdsDidError(string message)
        {

        }

        public void OnUnityAdsDidStart(string placementId)
        {

        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
                _callbackSuccessShowVideo?.Invoke();
        }
    }
}