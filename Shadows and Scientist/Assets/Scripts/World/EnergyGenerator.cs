using UnityEngine;

namespace WorldNamespace 
{
    public class EnergyGenerator : MonoBehaviour
    {
        [SerializeField] private PureEnergy _energyPrefab;

        [SerializeField] private int _energyAmount;

        [SerializeField] private Vector2Int _bordersLeftDown;
        [SerializeField] private Vector2Int _bordersRightUp;

        public void Init()
        {
            for(int i = 0; i < _energyAmount; i++)
            {
                float deviation = Random.Range(-9, 9) / 10f;

                Vector2 position = new Vector2(
                    Random.Range(_bordersLeftDown.x, _bordersRightUp.x) + deviation,
                    Random.Range(_bordersLeftDown.y, _bordersRightUp.y) + deviation
                    );

                PureEnergy energy = Instantiate(_energyPrefab, position, Quaternion.identity);
                energy.transform.parent = transform;
            }
        }
    }
}