using UnityEngine;
using SmallPlayerNamespace;
using PlayerNamespace;
using CursorNamespace;
using WorldNamespace;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private CursorUI _cursor;
    
    [SerializeField] private Map _map;

    [SerializeField] private EnergyGenerator _energyGenerator;

    private const int FPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = FPS;

        _playerManager.Init();
        _cursor.Init();
        _map.Init();
        _energyGenerator.Init();
    }
}
