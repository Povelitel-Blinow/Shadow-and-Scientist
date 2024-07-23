using UnityEngine;
using MaterialNamespace;

namespace SlotNamespace
{
    public abstract class Slot : MonoBehaviour
    {
        [SerializeField] private int _layer;

        protected InSlotPutable _slotPutable;
        protected bool _isVacant => _slotPutable == null;

        public virtual bool TryPut(InSlotPutable inSlotPutable) => false;

        public virtual void PutOut() { }

        private void OnValidate()
        {
            gameObject.layer = _layer;
        }
    }
}