using BuildingNameSpace;
using EnemyNamespace;
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

        [SerializeField] private GateWay[] _gateWays;
        [SerializeField] private Enemy _enemy;

        private float _timer = 0f;

        private bool _brokeIn = false;

        private bool _isRegitered = false;

        public Action<int, int> OnTick;

        public Transform GetBuildingTransform() => _buildingCenter;

        public void SetIsRegistered(bool isRegistered)
        {
            _isRegitered = isRegistered;
        }

        public void Pay(int mins)
        {
            _mins += mins;
            _timer = 0;
            Tick();
        }

        public void GetInBuilding()
        {
            CheckRent();
        }

        private void CheckRent()
        {
            if (_mins == 0 && _secs == 0)
            {
                BreakIn();
            }
            else
            {
                _brokeIn = false;
            }
        }

        private void BreakIn()
        {
            if (_brokeIn) return;

            _brokeIn = true;
            foreach(var g in _gateWays)
            {
                g.BreakIn(_enemy);
            }
            _mins += 1;
        }

        private void Update()
        {
            if (_isRegitered == false) return;

            _timer += Time.deltaTime;

            if (_timer > 1)
            {
                _timer -= 1;
                Tick();
            }

            CheckRent();
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