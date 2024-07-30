using CraftNamespace;
using MaterialNamespace;
using SlotNamespace;
using SmallWorldNamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class EnergySeeker : MonoBehaviour
    {
        [SerializeField] private InSlotPutable _energyPrefab;
        [SerializeField] private OutPutSlot _slot;

        [SerializeField] private LineTimer _line;

        [Header("Catching Energy")]
        [SerializeField] private float _catchRatio;

        private float _ratio = 0f;

        public static EnergySeeker Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        public void SetEnergyRangeRatio(float ratio)
        {
            _ratio = ratio;
            _line.SetLine(ratio);
        }

        public void Spawn()
        {
            if (_ratio >= _catchRatio)
            {
                if (SmallEnergySeeker.Instance.TryCatchEnergy() == false) return;

                _slot.PutInObject(_energyPrefab);
            }
        }
    }
}