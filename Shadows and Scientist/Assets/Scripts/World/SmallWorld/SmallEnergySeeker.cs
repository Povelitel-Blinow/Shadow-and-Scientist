using GadgetNamespace;
using System.Collections.Generic;
using UnityEngine;
using WorldNamespace;

namespace SmallWorldNamespace
{
    public class SmallEnergySeeker : MonoBehaviour
    {
        [SerializeField] private float _spotDistance;
        [SerializeField] private float _catchDistance;

        public static SmallEnergySeeker Instance { get; private set; }

        private List<PureEnergy> _pureEnergies = new List<PureEnergy>();

        public void Init()
        {
            Instance = this;
        }

        public void UpdateSeeker()
        {
            if (_pureEnergies.Count == 0) 
            {
                EnergySeeker.Instance.SetEnergyRangeRatio(0);
                return;
            }

            PureEnergy energy = FindClosestEnergy();
            float distance = (transform.position - energy.transform.position).magnitude;

            if (distance > _spotDistance) return;

            float ratio = GetValue(distance);

            EnergySeeker.Instance.SetEnergyRangeRatio(ratio);
        }

        private float GetValue(float distance)
        {
            if (distance <= _catchDistance)
            {
                return 1f;
            }
            else if (distance >= _spotDistance)
            {
                return 0f;
            }
            else
            {
                float t = (_spotDistance - distance) / (_spotDistance - _catchDistance);
                return Mathf.Clamp01(t);
            }
        }

        private PureEnergy FindClosestEnergy()
        {
            PureEnergy energy = _pureEnergies[0];
            float distance = (transform.position - energy.transform.position).magnitude;

            foreach(PureEnergy e in _pureEnergies)
            {
                float newDistance = (transform.position - e.transform.position).magnitude;
                if (newDistance < distance)
                {
                    distance = newDistance;
                    energy = e;
                }
            }

            return energy;
        }

        public bool TryCatchEnergy()
        {
            if (_pureEnergies.Count == 0) return false;

            PureEnergy pureEnergy = FindClosestEnergy();

            pureEnergy.Catch();

            UpdateSeeker();
            return true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out PureEnergy energy))
            {
                if (_pureEnergies.Contains(energy)) return;
                _pureEnergies.Add(energy);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PureEnergy energy))
            {
                if (_pureEnergies.Contains(energy) == false) return;
                _pureEnergies.Remove(energy);
            }
        }
    }
}
