using RentNamespace;
using UnityEngine;
using WorldNamespace;

namespace GadgetNamespace
{
    public class RentWindow : MonoBehaviour
    {
        [SerializeField] private RentTimeUI[] _timers;

        private Building _building;

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