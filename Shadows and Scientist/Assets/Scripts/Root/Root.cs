using UnityEngine;
using SmallPlayerNamespace;
using PlayerNamespace;
using CursorNamespace;

public class Root : MonoBehaviour
{
    [SerializeField] private SmallPlayer _smallplayer;
    [SerializeField] private Player _player;
    [SerializeField] private CursorUI _cursor;
    [SerializeField] private Map _map;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _smallplayer.Init();   
        _player.Init();
        _cursor.Init();
        _map.Init();
    }
}
