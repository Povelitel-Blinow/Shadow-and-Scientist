using MaterialNamespace;
using UnityEngine;

namespace SlotNamespace
{
    public class InputSlot : Slot
    {
        public override bool TryPut(InSlotPutable inSlotPutable)
        {
            if (_isVacant == false) return false;

            _slotPutable = inSlotPutable;

            return true;
        }
    }
}