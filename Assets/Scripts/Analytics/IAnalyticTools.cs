namespace Profile.Analytic
{
    internal interface IAnalyticTools
    {
        void SendMessage(string nameEvent);
        void SendMessage(string nameEvent, (string key, object value) data);
    }
}