using UnityEngine;
using SmallPlayerNamespace;
using PlayerNamespace;
using CursorNamespace;
using GadgetNamespace;

public class Root : MonoBehaviour
{
    [SerializeField] private SmallPlayer _smallplayer;
    [SerializeField] private Player _player;
    [SerializeField] private CursorUI _cursor;
    [SerializeField] private EnergySeeker _energySeeker;
    [SerializeField] private Map _map;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _smallplayer.Init();   
        _player.Init();
        _cursor.Init();
        _energySeeker.Init();
        _map.Init();
    }
}
