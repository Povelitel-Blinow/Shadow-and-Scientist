using UnityEngine;
using MaterialNamespace;

namespace SlotNamespace
{
    public abstract class Slot : MonoBehaviour
    {
        protected InSlotPutable _slotPutable;
        protected bool _isVacant => _slotPutable == null;

        public InSlotPutable InSlot => _slotPutable;

        public virtual bool TryPut(InSlotPutable inSlotPutable) => false;

        public virtual void PutOut() { }

        public virtual void VoidSlot()
        {
            if (_slotPutable == null) return;

            Destroy(_slotPutable.gameObject);
            _slotPutable = null;
        }
    }
}