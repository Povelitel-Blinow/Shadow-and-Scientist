using CraftNamespace;
using MaterialNamespace;
using SlotNamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class EnergySeeker : MonoBehaviour
    {
        [SerializeField] private InSlotPutable _energyPrefab;
        [SerializeField] private OutPutSlot _slot;

        [SerializeField] private LineTimer _line;

        public static EnergySeeker Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        public void SetEnergyRangeRatio(float ratio)
        {
            _line.SetLine(ratio);
        }

        public void Spawn()
        {
            _slot.PutInObject(_energyPrefab);
        }
    }
}