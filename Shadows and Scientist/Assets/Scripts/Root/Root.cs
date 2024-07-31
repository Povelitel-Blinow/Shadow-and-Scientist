using UnityEngine;
using SmallPlayerNamespace;
using PlayerNamespace;
using CursorNamespace;
using WorldNamespace;
using UnityEngine.SceneManagement;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private CursorUI _cursor;
    
    [SerializeField] private Map _map;

    [SerializeField] private EnergyGenerator _energyGenerator;

    [SerializeField] private PlayerTips _playerTips;

    private const int FPS = 60;

    private void Awake()
    {
        Time.timeScale = 1;

        Application.targetFrameRate = FPS;

        _playerTips.Init();

        _playerManager.Init();
        _cursor.Init();
        _map.Init();
        _energyGenerator.Init();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
