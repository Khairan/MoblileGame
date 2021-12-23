using System;


namespace Tools
{
    internal interface IAdsShower
    {
        void ShowBanner();
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}