using MaterialNamespace;
using UnityEngine;

namespace SlotNamespace
{
    public class BothPutSlot : Slot
    {
        public override bool TryPut(InSlotPutable inSlotPutable)
        {
            if(_isVacant == false) return false;

            _slotPutable = inSlotPutable;

            return true;
        }

        public override void PutOut()
        {
            if (_isVacant) return;

            _slotPutable = null;
        }
    }
}
