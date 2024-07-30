using GadgetNamespace;
using PlayerNamespace;
using SmallPlayerNamespace;
using UnityEngine;
using WorldNamespace;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SmallPlayer _smallPlayer;
    [SerializeField] private EnergySeeker _energySeeker;
    [SerializeField] private RentWindow _rentWindow;
    [SerializeField] private CameraBehaviour _cameraBehaviour;
    [SerializeField] private WorkPlace _workPlace;
    [SerializeField] private PlayerFear _playerFear;

    private Building _lastVisitedBuilding;

    public static PlayerManager Instance { get; private set; }

    public void Init()
    {
        Instance = this;

        _player.Init();
        _smallPlayer.Init();
        _energySeeker.Init();
        _workPlace.Init();
    }

    public void GoThroughtWall(GateWay way)
    {
        _smallPlayer.GoThroughtWall(way);
    }

    public void GetInBuilding(Building building)
    {
        _lastVisitedBuilding = building;
        _rentWindow.SetNewBuilding(building);
        building.GetInBuilding();

        _cameraBehaviour.MoveTo(building.GetBuildingTransform());
        _workPlace.Attach(building.GetBuildingTransform());
        _workPlace.OnBuildingEnter();
    }

    public void GetOutBuilding()
    {
        _cameraBehaviour.MoveTo(_smallPlayer.transform);
        _workPlace.Attach(_cameraBehaviour.transform);
        _workPlace.OnBuildingLeave();
    }

    public void RegisterScare(IScary scary) => _playerFear.RegisterScary(scary);
    public void DeRegisterScare(IScary scary) => _playerFear.DeregisterScary(scary);
}
