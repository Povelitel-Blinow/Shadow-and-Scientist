using MaterialNamespace;
using System;
using UnityEngine;

namespace SlotNamespace
{
    public class OutPutSlot : Slot
    {
        public Action OnPutOut;

        public void PutInObject(InSlotPutable inSlotPutablePrefab)
        {
            if (_isVacant == false) return;

            InSlotPutable spawned = Instantiate(inSlotPutablePrefab);

            _slotPutable = spawned;
            _slotPutable.InitByOutputSlot(this);
        }

        public override void PutOut()
        {
            if (_isVacant) return;

            Debug.Log(1);

            _slotPutable = null;
            OnPutOut?.Invoke();
        }
    }
}