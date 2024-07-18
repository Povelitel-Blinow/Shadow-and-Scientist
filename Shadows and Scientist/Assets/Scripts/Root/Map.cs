using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Vector2 _horizontalBorders;
    [SerializeField] private Vector2 _verticalBorders;

    public Vector2 HorizontalBorders => _horizontalBorders;
    public Vector2 VerticalBorders => _verticalBorders;

    public static Map Instance { get; private set; }

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
}
