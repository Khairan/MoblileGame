using Profile;
using Tools;
using UnityEngine;


namespace Game.InputLogic
{
    internal class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/TappingMove" };
        private BaseInputView _view;

        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<BaseInputView>();
        }
    }
}