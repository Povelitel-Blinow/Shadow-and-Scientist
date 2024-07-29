using BuildingNameSpace;
using System;
using UnityEngine;

namespace WorldNamespace
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Transform _buildingCenter;

        [SerializeField] private Roof _roof;

        [SerializeField] private int _mins;
        [SerializeField] private int _secs;

        private float _timer = 0f;

        public Action<int, int> OnTick;

        public Transform GetBuildingTransform() => _buildingCenter;

        public void GetInBuilding()
        {
            if(_mins == 0 &&  _secs == 0)
            {
                Debug.Log("Sniched");
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > 1)
            {
                _timer -= 1;
                Tick();
            }
        }

        private void Tick()
        {
            _secs -= 1;

            if (_secs < 0)
            {
                _mins -= 1;
                _secs = 59;

                if (_mins < 0)
                {
                    _mins = 0;
                    _secs = 0;
                }
            }

            OnTick?.Invoke(_mins, _secs);
        }

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