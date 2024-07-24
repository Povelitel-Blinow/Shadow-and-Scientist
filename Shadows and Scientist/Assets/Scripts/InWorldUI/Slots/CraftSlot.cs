using MaterialNamespace;
using System;

namespace SlotNamespace
{
    public class CraftSlot : Slot
    {
        private TheMaterial _material;

        public TheMaterial Material => _material;

        public Action OnPut;

        public override bool TryPut(InSlotPutable inSlotPutable)
        {
            if(_isVacant == false) return false;

            if(inSlotPutable.TryGetComponent(out TheMaterial material))
            {
                _material = material;
                _slotPutable = inSlotPutable;
                OnPut?.Invoke();
                return true;
            }

            return false;
        }

        public override void PutOut()
        {
            if (_isVacant) return;

            _slotPutable = null;
            _material = null;
        }
    }
}