using UnityEngine;
using SmallPlayerNamespace;

public class Root : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        _player.Init();   
    }
}
