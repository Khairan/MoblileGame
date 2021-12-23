using Profile.Analytic;
using Tools;


namespace Profile
{
    internal class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }
        public IAdsShower AdsShower { get; }

        public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = new UnityAnalyticTools();
            AdsShower = unityAdsTools;
        }
    }
}