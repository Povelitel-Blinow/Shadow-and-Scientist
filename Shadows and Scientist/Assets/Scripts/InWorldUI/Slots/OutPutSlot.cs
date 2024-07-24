using MaterialNamespace;

namespace SlotNamespace
{
    public class OutPutSlot : Slot
    {
        public void PutInObject(InSlotPutable inSlotPutablePrefab)
        {
            if (_isVacant == false) return;

            InSlotPutable energy = Instantiate(inSlotPutablePrefab);

            _slotPutable = energy;
            _slotPutable.InitByOutputSlot(this);
        }

        public override void PutOut()
        {
            if (_isVacant) return;

            _slotPutable = null;
        }
    }
}