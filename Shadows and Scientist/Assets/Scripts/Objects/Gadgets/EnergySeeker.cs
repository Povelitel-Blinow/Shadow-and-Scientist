using MaterialNamespace;
using SlotNamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class EnergySeeker : MonoBehaviour
    {
        [SerializeField] private InSlotPutable _energyPrefab;
        [SerializeField] private OutPutSlot _slot;

        public void Spawn()
        {
            

            _slot.PutInObject(_energyPrefab);
        }
    }
}