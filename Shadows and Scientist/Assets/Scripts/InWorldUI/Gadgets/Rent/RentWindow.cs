using RentNamespace;
using UnityEngine;
using WorldNamespace;
using SlotNamespace;
using MaterialNamespace;

namespace GadgetNamespace
{
    public class RentWindow : MonoBehaviour
    {
        [SerializeField] private RentTimeUI[] _timers;

        [SerializeField] private CraftSlot _inputSlot;

        private Building _building;

        private void Start()
        {
            _inputSlot.OnPut += TryPayRent;
        }

        private void TryPayRent()
        {
            if (_building == null) return;

            if (_inputSlot.Material.MaterialType == MaterialType.Gold)
            {
                _building.Pay(1);
            }
            else if (_inputSlot.Material.MaterialType == MaterialType.Coin)
            {
                _building.Pay(2);
            }

            _inputSlot.VoidSlot();
        }

        public void SetNewBuilding(Building building)
        {
            if (_building != null)
                _building.OnTick -= UpdateTimers;

            _building = building;
            _building.OnTick += UpdateTimers;
        }

        private void UpdateTimers(int mins, int secs)
        {
            foreach (var timer in _timers)
            {
                timer.SetTime(mins, secs);
            }
        }
    }
}