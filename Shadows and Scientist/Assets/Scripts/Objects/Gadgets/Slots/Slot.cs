using UnityEngine;
using MaterialNamespace;

namespace SlotNamespace
{
    public abstract class Slot : MonoBehaviour
    {
        protected InSlotPutable _slotPutable;
        protected bool _isVacant => _slotPutable == null;

        public virtual bool TryPut(InSlotPutable inSlotPutable) => false;

        public virtual void PutOut() { }
    }
}