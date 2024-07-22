using ObjectsNamespace;
using SlotNamespace;
using UnityEngine;

namespace MaterialNamespace
{
    public class InSlotPutable : Moveable
    {
        [Header("InSlotPutable params")]
        [SerializeField] private LayerMask _slotLayer;

        private float _raycastDistance = 100;

        private Slot _slot;

        protected override void OnLayDown()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, _raycastDistance, _slotLayer);

            if(hit.collider == null) return;

            if (hit.collider.TryGetComponent(out Slot slot))
            {
                TryPutInSlot(slot);
            }
        }

        private void TryPutInSlot(Slot parentSlot)
        {
            if (parentSlot.TryPut(this))
            {
                _slot = parentSlot;
                MoveToSlot(_slot);
            }
        }

        private void MoveToSlot(Slot slot)
        {
            transform.position = slot.transform.position + GetSortingOffset();
            transform.parent = slot.transform;
        }

        /// <summary>
        /// This method is used by OutputSlots ONLY
        /// </summary>
        /// <param name="outputSlot"></param>
        public void InitByOutputSlot(Slot outputSlot)
        {
            _slot = outputSlot;
            MoveToSlot(outputSlot);
        }

        protected override void OnPickUp()
        {
            transform.parent = null;

            if(_slot == null) return;

            _slot.PutOut();

            _slot = null;
        }
    }
}