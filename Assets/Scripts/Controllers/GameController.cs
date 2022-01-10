using Game.InputLogic;
using Profile;
using System.Linq;
using Tools;

internal class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();

        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);

        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);

        var carController = new CarController();
        AddController(carController);

        var _configsPath = new ResourcePath { PathResource = "DataSource/Upgrades/UpgradeItemConfigDataSource" };
        var shedController = new ShedController(ResourceLoader.LoadConfig(_configsPath).itemConfigs.ToList(), profilePlayer.CurrentCar);
        AddController(shedController);
    }
}