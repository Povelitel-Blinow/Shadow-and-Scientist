using BuildingNameSpace;
using UnityEngine;

namespace WorldNamespace
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Transform _buildingCenter;

        [SerializeField] private Roof _roof;

        public Transform GetBuildingTransform() => _buildingCenter;

        public void ShowRoof()
        {
            _roof.ShowRoof();
        }

        public void HideRoof()
        {
            _roof.HideRoof();
        }
    }
}